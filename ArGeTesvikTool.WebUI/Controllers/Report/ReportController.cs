using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Business.Abstract.Report;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.Report;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ArGeTesvikTool.WebUI.Controllers.Report
{
    [Authorize]
    public class ReportController : BaseController
    {
        private readonly IRdCenterCalPersonnelEntryService _persEntryService;
        private readonly IRdCenterCalPublicHolidayService _holidayService;
        private readonly IRdCenterCalTimeAwayService _timeAwayService;
        private readonly IRdCenterCalPersAttendanceService _persAttendance;
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterTechProjectService _projService;
        private readonly IIncomeService _income;
        private readonly ISocialSecurityService _socialSecurity;
        private readonly IExportExcelService _excelService;

        public ReportController(IRdCenterCalPersonnelEntryService persEntryService, IRdCenterCalPublicHolidayService holidayService, IRdCenterCalTimeAwayService timeAwayService, IRdCenterCalPersAttendanceService persAttendance, IRdCenterTechProjectService projService, IRdCenterPersonInfoService infoService, IIncomeService income, ISocialSecurityService socialSecurity, IExportExcelService excelService, UserManager<AppIdentityUser> userManager) : base(userManager, null, null)
        {
            _persEntryService = persEntryService;
            _holidayService = holidayService;
            _timeAwayService = timeAwayService;
            _persAttendance = persAttendance;
            _projService = projService;
            _infoService = infoService;

            _income = income;
            _socialSecurity = socialSecurity;

            _excelService = excelService;
        }
        public IActionResult Income()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);
            ReportViewModel reportViewModel = new()
            {
                StartDate = startDate,
                EndDate = startDate.AddMonths(1).AddDays(-1)
            };

            return View(reportViewModel);
        }

        [HttpPost]
        public IActionResult Income(ReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            var personnelEntries = _persEntryService.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);

            if (personnelEntries.Count == 0)
            {
                AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
                return View(reportViewModel);
            }

            List<IncomeDto> incomeList = new();
            foreach (var item in personnelEntries)
            {
                IncomeDto newIncome = new();

                newIncome.RegistrationNo = item.RegistrationNo;
                newIncome.PersonnelFullName = item.PersonnelFullName;

                decimal timediff = Convert.ToDecimal((item.EndDate.Subtract(item.StartDate)).TotalHours);

                #region Ar-Ge Merkezi İçerisinde Geçirilen Süre
                if (!string.IsNullOrEmpty(item.ProjectCode))
                {
                    newIncome.RdCenterTimeSpend = IsTimeBiggerThanEight(ref timediff);
                }
                #endregion

                #region Uzaktan Çalışma Süresi
                if (item.TimeAwayCode == "12")
                {
                    newIncome.RemoteTimeSpend = IsTimeBiggerThanEight(ref timediff);
                }
                #endregion

                #region Projeler veya Lisansüstü Eğitim Kapsamında Ar-Ge Merkezi Dışında Geçirilen Teşvikli Süre
                if (Convert.ToInt32(item.TimeAwayCode) >= 1 && Convert.ToInt32(item.TimeAwayCode) <= 11)
                {
                    newIncome.ProjectTimeSpend = IsTimeBiggerThanEight(ref timediff);
                }
                #endregion

                #region Ar-Ge Merkezi Dışında Geçirilen Diğer Teşviksiz R&D Zamanı
                if (item.WorkType == "Tam Zamanlı" && item.TimeAwayCode == "98")
                {
                    newIncome.UncentiveTimeSpend = timediff;
                }
                #endregion

                #region Ar-Ge Merkezi Dışında Geçirilen Non R&D Zamanı
                if (item.WorkType == "Kısmi Zamanlı" && item.TimeAwayCode == "99")
                {
                    newIncome.NonRdCenterTimeSpend = timediff;
                }
                #endregion

                #region Ar-Ge Merkezi Dışında Geçirilen Diğer Zamanlar
                if (item.TimeAwayCode == "91")
                {
                    newIncome.NonRdCenterOtherTimeSpend = timediff;
                }
                #endregion

                #region Ücretli Yıllık İzinler
                if (item.TimeAwayCode == "90")
                {
                    newIncome.AnnualLeaveTimeSpend = timediff;
                }
                #endregion

                incomeList.Add(newIncome);
            }

            //get working days between given start and end date
            List<RdCenterCalPublicHolidayDto> publicholidays = _holidayService.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);
            List<DateTime> publicholidayList = new();
            foreach (var item in publicholidays)
            {
                int timeDiff = Convert.ToInt32(item.EndDate.Subtract(item.StartDate).TotalHours);
                for (int i = 0; i < timeDiff; i++)
                {
                    publicholidayList.Add(item.StartDate.AddDays(i));
                }
            }
            int businessDayCount = GetBusinessDays(reportViewModel.StartDate, reportViewModel.EndDate, publicholidayList);
            int weekendDayCount = GetWeekendDays(reportViewModel.StartDate);

            var collect = incomeList
                .GroupBy(x => new
                {
                    x.RegistrationNo
                })
                .Select(x => new IncomeDto
                {
                    RegistrationNo = x.Key.RegistrationNo,
                    PersonnelFullName = x.First().PersonnelFullName,
                    RdCenterTimeSpend = x.Sum(x => x.RdCenterTimeSpend),
                    RemoteTimeSpend = x.Sum(x => x.RemoteTimeSpend),
                    ProjectTimeSpend = x.Sum(x => x.ProjectTimeSpend),
                    UncentiveTimeSpend = x.Sum(x => x.UncentiveTimeSpend),
                    NonRdCenterTimeSpend = x.Sum(x => x.NonRdCenterTimeSpend),
                    NonRdCenterOtherTimeSpend = x.Sum(x => x.NonRdCenterOtherTimeSpend),
                    AnnualLeaveTimeSpend = x.Sum(x => x.AnnualLeaveTimeSpend),
                    BaseUsedDay = x.First().BaseUsedDay
                })
                .ToList();

            foreach (var item in collect)
            {
                decimal netWorkingTime = businessDayCount * 8 - item.AnnualLeaveTimeSpend;
                decimal incentiveWorkingTime = item.RdCenterTimeSpend + item.RemoteTimeSpend + item.ProjectTimeSpend;
                decimal incentiveRate = incentiveWorkingTime / netWorkingTime;
                decimal incentiveWeekendRate = weekendDayCount * incentiveRate;
                decimal publicHolidayRate = publicholidays.Count * incentiveRate;
                decimal annualLeave = item.AnnualLeaveTimeSpend * incentiveRate;
                decimal incentiveTimeTotal = incentiveWorkingTime + incentiveWeekendRate + publicHolidayRate + annualLeave;
                decimal incentiveDayCount = incentiveTimeTotal / 8;

                item.BaseUsedDay = Math.Floor(incentiveDayCount);
            }

            var checkIsExists = _income.GetByYearByMonth(reportViewModel.StartDate.Year, reportViewModel.StartDate.Month);
            if (checkIsExists == null)
            {
                _income.AddList(collect);
            }

            var content = _excelService.IncomeExportExcel(collect, "Gelir Vergisi Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Gelir Vergisi Rapor.xlsx");
        }

        public IActionResult SocialSecurity()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);
            ReportViewModel reportViewModel = new()
            {
                StartDate = startDate,
                EndDate = startDate.AddMonths(1).AddDays(-1)
            };

            return View(reportViewModel);
        }

        [HttpPost]
        public IActionResult SocialSecurity(ReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            var personnelEntries = _persEntryService.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);

            if (personnelEntries.Count == 0)
            {
                AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
                return View(reportViewModel);
            }

            List<SocialSecurityDto> ssiList = new();

            foreach (var item in personnelEntries)
            {
                SocialSecurityDto newSsi = new();

                decimal timediff = Convert.ToDecimal((item.EndDate.Subtract(item.StartDate)).TotalHours);

                newSsi.PersonnelFullName = item.PersonnelFullName;
                newSsi.RegistrationNo = item.RegistrationNo;
                newSsi.WorkType = item.WorkType;

                newSsi.WeekNumber = GetCurrentDayOfWeekNumber(item.StartDate);

                //GetPreMonthActivities(reportViewModel.StartDate);

                #region Teşvikli çalışma süresi
                if (Convert.ToInt32(item.TimeAwayCode) >= 1 && Convert.ToInt32(item.TimeAwayCode) <= 12)
                {
                    if (newSsi.WeekNumber == 1)
                        newSsi.PreMonthTransfer = GetPreMonthActivities(item.RegistrationNo, item.StartDate);

                    newSsi.IncentiveWorkingHour = timediff;
                }
                #endregion

                #region Yıllık izin süresi
                if (item.TimeAwayCode == "90")
                {
                    if (newSsi.WeekNumber == 1)
                        newSsi.PreMonthAnnuelLeaveHour = GetPreMonthAnnuelLeaveHour(item.RegistrationNo, item.StartDate);

                    newSsi.AnnuelLeaveWorkingHour = timediff;
                }
                #endregion

                ssiList.Add(newSsi);
            }

            //get working days between given start and end date
            List<RdCenterCalPublicHolidayDto> publicholidays = _holidayService.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);
            List<DateTime> publicholidayList = new();
            foreach (var item in publicholidays)
            {
                publicholidayList.Add(item.StartDate);
            }

            int businessDayCount = GetBusinessDays(reportViewModel.StartDate, reportViewModel.EndDate, publicholidayList);
            int weekendDayCount = GetWeekendDays(reportViewModel.StartDate);

            var collect = ssiList
                .GroupBy(x => new
                {
                    x.RegistrationNo,
                    x.WeekNumber
                })
                .Select(x => new SocialSecurityDto
                {
                    RegistrationNo = x.Key.RegistrationNo,
                    PersonnelFullName = x.First().PersonnelFullName,
                    WorkType = x.First().WorkType,
                    WeekNumber = x.Key.WeekNumber,
                    PreMonthTransfer = x.First().PreMonthTransfer,
                    IncentiveWorkingHour = x.Sum(x => x.IncentiveWorkingHour),
                    PreMonthAnnuelLeaveHour = x.Sum(x => x.PreMonthAnnuelLeaveHour),
                    AnnuelLeaveWorkingHour = x.Sum(x => x.AnnuelLeaveWorkingHour),
                })
                .ToList();

            foreach (var item in collect)
            {
                if (item.WeekNumber == 1)
                    item.WeekendWorkingHour = (int)(item.PreMonthTransfer + item.IncentiveWorkingHour + item.PreMonthAnnuelLeaveHour + item.AnnuelLeaveWorkingHour) >= 40 ? 16 : 0;
                else
                    item.WeekendWorkingHour = (int)(item.IncentiveWorkingHour + item.AnnuelLeaveWorkingHour);

                item.PublicHolidayWorkingHour = publicholidays.Count * 8;

                decimal monthlyincentiveTotalTime = item.IncentiveWorkingHour + item.WeekendWorkingHour;
                decimal netWorkingTime = businessDayCount * 8 - item.AnnuelLeaveWorkingHour;
                decimal incentiveRate = item.IncentiveWorkingHour / netWorkingTime;
                decimal annualLeave = item.AnnuelLeaveWorkingHour * incentiveRate;
                decimal publicHolidayRate = publicholidays.Count * incentiveRate;

                decimal incentiveTimeTotal = (monthlyincentiveTotalTime + annualLeave + publicHolidayRate) / 8;

                item.SsiWorkingHour = Math.Floor(incentiveTimeTotal);
            }

            var checkIsExists = _socialSecurity.GetByYearByMonth(reportViewModel.StartDate.Year, reportViewModel.StartDate.Month);
            if (checkIsExists == null)
            {
                _socialSecurity.AddList(collect);
            }

            var content = _excelService.SsiExportExcel(collect, "SGK Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SGK Rapor.xlsx");
        }

        public IActionResult PersonnelActivityReport()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);

            var projectRelated = new SelectListGroup { Name = "Proje İlişkili" };
            var nonProjectRelated = new SelectListGroup { Name = "Proje İlişkisiz" };
            var timeAwayList = _timeAwayService.GetAll();

            var projectList = _projService.GetAllProjectName();

            List<SelectListItem> timeAwaySelectList = new();
            foreach (var item in timeAwayList)
            {
                if (Convert.ToInt32(item.TimeAwayCode) >= 1 && Convert.ToInt32(item.TimeAwayCode) <= 12)
                {
                    timeAwaySelectList.Add(new SelectListItem
                    {
                        Value = item.TimeAwayCode,
                        Text = item.TimeAwayName,
                        Group = projectRelated
                    });
                }
                else
                {
                    timeAwaySelectList.Add(new SelectListItem
                    {
                        Value = item.TimeAwayCode,
                        Text = item.TimeAwayName,
                        Group = nonProjectRelated
                    });
                }
            }

            ActivityReportViewModel reportViewModel = new()
            {
                StartDate = startDate,
                EndDate = startDate.AddMonths(1).AddDays(-1),
                ProjectList = projectList.Select(x => new SelectListItem
                {
                    Value = x.ProjectCode,
                    Text = x.ProjectName,
                }).ToList(),
                TimeAwayList = timeAwaySelectList
            };

            return View(reportViewModel);
        }

        [HttpPost]
        public IActionResult PersonnelActivityReport(ActivityReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _userManager.FindByIdAsync(userId).Result;

            string[] projectList = Request.Form["projectList"];
            string[] timeAwayList = Request.Form["timeAwayList"];

            var result = _persEntryService.GetAllByMonthByPersonnel(currentUser.RegistrationNo, reportViewModel.StartDate, reportViewModel.EndDate);

            if (projectList.Length > 0)
            {
                result = result.Where(x => projectList.Contains(x.ProjectCode)).ToList();
            }

            if (timeAwayList.Length > 0)
            {
                result = result.Where(x => timeAwayList.Contains(x.TimeAwayCode)).ToList();
            }

            if (result.Count == 0)
            {
                AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
                return View(reportViewModel);
            }

            var content = _excelService.ActivityExportExcel(result, "Personel Aktivite Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Personel Aktivite Rapor.xlsx");
        }

        public IActionResult PersonnelReport()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);

            ActivityReportViewModel reportViewModel = new()
            {
                StartDate = startDate,
                EndDate = startDate.AddMonths(1).AddDays(-1),
            };

            return View(reportViewModel);
        }

        [HttpPost]
        public IActionResult PersonnelReport(ActivityReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _userManager.FindByIdAsync(userId).Result;

            var result = _persAttendance.GetAllByMonthByPersonnelId(currentUser.RegistrationNo, reportViewModel.StartDate, reportViewModel.EndDate);

            if (result.Count == 0)
            {
                AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
                return View(reportViewModel);
            }

            var content = _excelService.PdksExportExcel(result, "Personel Pdks Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Personel Pdks Rapor.xlsx");
        }

        public IActionResult ManagerActivityReport()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);

            var projectRelated = new SelectListGroup { Name = "Proje İlişkili" };
            var nonProjectRelated = new SelectListGroup { Name = "Proje İlişkisiz" };

            var timeAwayList = _timeAwayService.GetAll();
            var projectList = _projService.GetAllProjectName();
            var personnelList = _infoService.GetAllByYear(2022);

            List<SelectListItem> timeAwaySelectList = new();
            foreach (var item in timeAwayList)
            {
                if (Convert.ToInt32(item.TimeAwayCode) >= 1 && Convert.ToInt32(item.TimeAwayCode) <= 12)
                {
                    timeAwaySelectList.Add(new SelectListItem
                    {
                        Value = item.TimeAwayCode,
                        Text = item.TimeAwayName,
                        Group = projectRelated
                    });
                }
                else
                {
                    timeAwaySelectList.Add(new SelectListItem
                    {
                        Value = item.TimeAwayCode,
                        Text = item.TimeAwayName,
                        Group = nonProjectRelated
                    });
                }
            }

            ActivityReportViewModel reportViewModel = new()
            {
                StartDate = startDate,
                EndDate = startDate.AddMonths(1).AddDays(-1),
                ProjectList = projectList.Select(x => new SelectListItem
                {
                    Value = x.ProjectCode,
                    Text = x.ProjectName,
                }).ToList(),
                TimeAwayList = timeAwaySelectList,
                PersonnelList = personnelList.Select(x => new SelectListItem
                {
                    Value = x.RegistrationNo,
                    Text = x.NameSurname,
                }).ToList(),
            };

            return View(reportViewModel);
        }

        [HttpPost]
        public IActionResult ManagerActivityReport(ActivityReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            string[] projectList = Request.Form["projectList"];
            string[] timeAwayList = Request.Form["timeAwayList"];
            string[] personnelList = Request.Form["personnelList"];

            var result = _persEntryService.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);

            if (projectList.Length > 0)
            {
                result = result.Where(x => projectList.Contains(x.ProjectCode)).ToList();
            }

            if (timeAwayList.Length > 0)
            {
                result = result.Where(x => timeAwayList.Contains(x.TimeAwayCode)).ToList();
            }

            if (personnelList.Length > 0)
            {
                result = result.Where(x => personnelList.Contains(x.RegistrationNo)).ToList();
            }

            if (result.Count == 0)
            {
                AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
                return View(reportViewModel);
            }

            var content = _excelService.ActivityExportExcel(result, "Yönetici Aktivite Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Yönetici Aktivite Rapor.xlsx");
        }

        public IActionResult ManagerReport()
        {
            var personnelList = _infoService.GetAllByYear(2022);

            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);

            ActivityReportViewModel reportViewModel = new()
            {
                StartDate = startDate,
                EndDate = startDate.AddMonths(1).AddDays(-1),
                PersonnelList = personnelList.Select(x => new SelectListItem
                {
                    Value = x.RegistrationNo,
                    Text = x.NameSurname,
                }).ToList(),
            };

            return View(reportViewModel);
        }

        [HttpPost]
        public IActionResult ManagerReport(ActivityReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            var result = _persAttendance.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);

            string[] personnelList = Request.Form["personnelList"];

            if (personnelList.Length > 0)
            {
                result = result.Where(x => personnelList.Contains(x.UserId)).ToList();
            }

            if (result.Count == 0)
            {
                AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
                return View(reportViewModel);
            }

            var content = _excelService.PdksExportExcel(result, "Yönetici Pdks Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Yönetici Pdks Rapor.xlsx");
        }

        private bool DateControl(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                AddErrorMessage("Başlangıç tarihi bitiş tarihinden büyük olamaz.");
                return false;
            }
            return true;
        }

        private decimal GetPreMonthActivities(string regNo, DateTime date)
        {
            DateTime firstDateOfMonth = new(date.Year, date.Month, 1);

            int firstDayOfMonth = (int)(firstDateOfMonth.DayOfWeek - 1) * -1;
            DateTime startDate = firstDateOfMonth.AddDays(firstDayOfMonth);

            var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            DateTime endDate = new(startDate.Year, startDate.Month, daysInMonth);

            var personnelEntries = _persEntryService.GetAllByMonthByPersonnel(regNo, startDate, endDate);

            decimal preMonthTransfer = 0;
            foreach (var item in personnelEntries)
            {
                if (Convert.ToInt32(item.TimeAwayCode) >= 1 && Convert.ToInt32(item.TimeAwayCode) <= 12)
                {
                    preMonthTransfer += Convert.ToDecimal(item.EndDate.Subtract(item.StartDate).TotalHours);
                }
            }

            return preMonthTransfer;
        }

        private decimal GetPreMonthAnnuelLeaveHour(string regNo, DateTime date)
        {
            DateTime firstDateOfMonth = new(date.Year, date.Month, 1);

            int firstDayOfMonth = (int)(firstDateOfMonth.DayOfWeek - 1) * -1;
            DateTime startDate = firstDateOfMonth.AddDays(firstDayOfMonth);

            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            var personnelEntries = _persEntryService.GetAllByMonthByPersonnel(regNo, startDate, endDate);

            decimal preMonthTransfer = 0;
            foreach (var item in personnelEntries)
            {
                if (item.TimeAwayCode == "90")
                {
                    preMonthTransfer += Convert.ToDecimal((item.EndDate.Subtract(item.StartDate)).TotalHours);
                }
            }

            return preMonthTransfer;
        }

        private static int GetBusinessDays(DateTime startDate, DateTime endDate, List<DateTime> holidays)
        {
            return Enumerable.Range(0, (endDate - startDate).Days)
                .Select(a => startDate.AddDays(a))
                .Where(a => a.DayOfWeek != DayOfWeek.Sunday)
                .Where(a => a.DayOfWeek != DayOfWeek.Saturday)
                .Count(a => !holidays.Any(x => x == a));
        }

        private static int GetWeekendDays(DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            DateTime firstOfMonth = new(date.Year, date.Month, 1);

            //days of week starts by default as Sunday = 0
            int firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
            decimal weeksInMonth = (decimal)(firstDayOfMonth + daysInMonth) / 7;

            return (int)Math.Round(weeksInMonth);
        }

        private static int GetCurrentDayOfWeekNumber(DateTime date)
        {
            DateTime beginningOfMonth = new(date.Year, date.Month, 1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }

        private static decimal IsTimeBiggerThanEight(ref decimal timediff)
        {
            //if daily time is bigger than 8 hours. do it default 8
            if (timediff > 8)
            {
                timediff = 8;
            }
            return timediff;
        }
    }
}
