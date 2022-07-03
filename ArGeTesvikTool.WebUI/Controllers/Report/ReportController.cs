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
using System.Globalization;
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
        private readonly ITeleworkingService _teleworking;
        private readonly IExportExcelService _excelService;

        public ReportController(IRdCenterCalPersonnelEntryService persEntryService, IRdCenterCalPublicHolidayService holidayService, IRdCenterCalTimeAwayService timeAwayService, IRdCenterCalPersAttendanceService persAttendance, IRdCenterTechProjectService projService, IRdCenterPersonInfoService infoService, IIncomeService income, ISocialSecurityService socialSecurity, ITeleworkingService teleworking, IExportExcelService excelService, UserManager<AppIdentityUser> userManager) : base(userManager, null, null)
        {
            _persEntryService = persEntryService;
            _holidayService = holidayService;
            _timeAwayService = timeAwayService;
            _persAttendance = persAttendance;
            _projService = projService;
            _infoService = infoService;

            _income = income;
            _socialSecurity = socialSecurity;
            _teleworking = teleworking;

            _excelService = excelService;
        }

        #region Gelir Vergisi
        [Route("gelir-vergi-rapor")]
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
        [Route("gelir-vergi-rapor")]
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
                IncomeDto newIncome = new()
                {
                    RegistrationNo = item.RegistrationNo,
                    PersonnelFullName = item.PersonnelFullName,
                    WorkType = item.WorkType
                };

                decimal timediff = Convert.ToDecimal((item.EndDate.Subtract(item.StartDate)).TotalHours);

                //if daily activity is bigger than 8 hours, do it 8 always
                timediff = IsTimeBiggerThanEight(ref timediff);

                #region Ar-Ge Merkezi İçerisinde Geçirilen Süre
                if (string.IsNullOrEmpty(item.TimeAwayCode))
                {
                    newIncome.RdCenterTimeSpend = timediff;
                }
                #endregion

                #region Uzaktan Çalışma Süresi
                if (item.TimeAwayCode == "12")
                {
                    newIncome.RemoteTimeSpend = timediff;
                }
                #endregion

                #region Projeler veya Lisansüstü Eğitim Kapsamında Ar-Ge Merkezi Dışında Geçirilen Teşvikli Süre
                if (Convert.ToInt32(item.TimeAwayCode) >= 1 && Convert.ToInt32(item.TimeAwayCode) <= 11)
                {
                    newIncome.ProjectTimeSpend = timediff;
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
                int diffDays = Convert.ToInt32(item.EndDate.Subtract(item.StartDate).TotalDays);
                for (int i = 0; i <= diffDays; i++)
                {
                    publicholidayList.Add(new(item.StartDate.Year, item.StartDate.Month, item.StartDate.Day, 0, 0, 0, 0));
                    item.StartDate = item.StartDate.AddDays(1);
                }
            }

            int businessDayCount = GetBusinessDays(reportViewModel.StartDate, reportViewModel.EndDate, publicholidayList);
            int weekendDayCount = GetWeekendDays(reportViewModel.StartDate, businessDayCount, publicholidayList);

            var collect = incomeList
                .GroupBy(x => new
                {
                    x.RegistrationNo
                })
                .Select(x => new IncomeDto
                {
                    Year = reportViewModel.StartDate.Year,
                    Month = reportViewModel.StartDate.Month,
                    RegistrationNo = x.Key.RegistrationNo,
                    PersonnelFullName = x.First().PersonnelFullName,
                    WorkType = x.First().WorkType,
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
                decimal incentiveWeekendRate = weekendDayCount * 8 * incentiveRate;
                decimal publicHolidayRate = publicholidayList.Count * 8 * incentiveRate;
                decimal annualLeave = item.AnnualLeaveTimeSpend * incentiveRate;
                decimal incentiveTimeTotal = 0;
                if (item.WorkType == "Kısmi")
                {
                    incentiveTimeTotal = incentiveWorkingTime;
                }
                if (item.WorkType == "Tam")
                {
                    incentiveTimeTotal = incentiveWorkingTime + incentiveWeekendRate + publicHolidayRate + annualLeave;
                }
                decimal incentiveDayCount = incentiveTimeTotal / 8;

                item.BaseUsedDay = Math.Floor(incentiveDayCount) > 30 ? 30 : Math.Floor(incentiveDayCount);
            }

            incomeList.Clear();
            incomeList = _income.GetByYearByMonth(reportViewModel.StartDate.Year, reportViewModel.StartDate.Month);
            if (incomeList.Count > 0)
                _income.DeleteList(incomeList);

            _income.AddList(collect);

            var content = _excelService.IncomeExportExcel(collect, "Gelir Vergisi Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Gelir Vergisi Rapor.xlsx");
        }

        [Route("gelir-vergi-rapor-indir")]
        public IActionResult IncomeDownload()
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
        [Route("gelir-vergi-rapor-indir")]
        public IActionResult IncomeDownload(ReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            List<IncomeDto> incomeList = _income.GetByYearByMonth(reportViewModel.StartDate.Year, reportViewModel.StartDate.Month);
            if (incomeList.Count != 0)
            {
                var excelDownload = _excelService.IncomeExportExcel(incomeList, "Gelir Vergisi Rapor");

                return File(
                    excelDownload,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Gelir Vergisi Rapor.xlsx");
            }

            AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
            return View(reportViewModel);
        }
        #endregion

        #region SGK
        [Route("sgk-rapor")]
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
        [Route("sgk-rapor")]
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

            personnelEntries = personnelEntries.Where(x => x.PersonnelFullName == "kullanici6 pwc").ToList();
            personnelEntries = personnelEntries.OrderBy(x => x.RegistrationNo)
                                               .ThenBy(x => x.StartDate)
                                               .ToList();
            foreach (var item in personnelEntries)
            {
                SocialSecurityDto newSsi = new();

                decimal timediff = Convert.ToDecimal((item.EndDate.Subtract(item.StartDate)).TotalHours);

                //if daily activity is bigger than 8 hours, do it 8 always
                timediff = IsTimeBiggerThanEight(ref timediff);

                newSsi.PersonnelFullName = item.PersonnelFullName;
                newSsi.RegistrationNo = item.RegistrationNo;
                newSsi.WorkType = item.WorkType;

                newSsi.WeekNumber = GetCurrentDayOfWeekNumber(item.StartDate);

                #region Teşvikli çalışma süresi
                if (!string.IsNullOrEmpty(item.ProjectCode))
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
            List<Tuple<DateTime, int>> publicholidayWeekNumber = new();

            publicholidays = publicholidays.OrderBy(x => x.StartDate).ToList();
            foreach (var item in publicholidays)
            {
                int diffDays = Convert.ToInt32(item.EndDate.Subtract(item.StartDate).TotalDays);
                for (int i = 0; i <= diffDays; i++)
                {
                    publicholidayList.Add(new(item.StartDate.Year, item.StartDate.Month, item.StartDate.Day, 0, 0, 0, 0));
                    /*eğer resmi tatil ayın ilk günü ve hafta sonu ise, hafta sonu numarasını farklı yap. sgk hesaplamasında yanlışlık oluşuyor*/
                    if ((item.StartDate.DayOfWeek == DayOfWeek.Saturday || item.StartDate.DayOfWeek == DayOfWeek.Sunday) && item.StartDate.Day == 1)
                        publicholidayWeekNumber.Add(new Tuple<DateTime, int>(item.StartDate, 10));
                    else
                        publicholidayWeekNumber.Add(new Tuple<DateTime, int>(item.StartDate, GetCurrentDayOfWeekNumber(item.StartDate)));

                    item.StartDate = item.StartDate.AddDays(1);
                }
            }

            int businessDayCount = GetBusinessDays(reportViewModel.StartDate, reportViewModel.EndDate, publicholidayList);
            int weekendDayCount = GetWeekendDays(reportViewModel.StartDate, businessDayCount, publicholidayList);

            var totalTimeList = ssiList
                .GroupBy(x => new
                {
                    x.RegistrationNo,
                })
                .Select(x => new SocialSecurityDto
                {
                    Year = reportViewModel.StartDate.Year,
                    Month = reportViewModel.StartDate.Month,
                    RegistrationNo = x.Key.RegistrationNo,
                    PersonnelFullName = x.First().PersonnelFullName,
                    WorkType = x.First().WorkType,
                    PreMonthTransfer = x.First().PreMonthTransfer,
                    IncentiveWorkingHour = x.Sum(x => x.IncentiveWorkingHour),
                    PreMonthAnnuelLeaveHour = x.Sum(x => x.PreMonthAnnuelLeaveHour),
                    AnnuelLeaveWorkingHour = x.Sum(x => x.AnnuelLeaveWorkingHour),
                })
                .ToList();

            var collect = ssiList
                .GroupBy(x => new
                {
                    x.RegistrationNo,
                    x.WeekNumber
                })
                .Select(x => new SocialSecurityDto
                {
                    Year = reportViewModel.StartDate.Year,
                    Month = reportViewModel.StartDate.Month,
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

            var weekNumberList = collect.Select(x => x.WeekNumber).ToList();
            int lastWeekNumber = weekNumberList.Last();

            collect = collect.OrderBy(x => x.RegistrationNo)
                             .ThenBy(x => x.WeekNumber)
                             .ToList();
            foreach (var item in collect)
            {
                var weekNumber = publicholidayWeekNumber.Where(x => x.Item2 == item.WeekNumber).Count();
                if (weekNumber > 0)
                    item.PublicHolidayWorkingHour = weekNumber * 8;

                if (item.WeekNumber == 1)
                    item.WeekendWorkingHour = (int)(item.PreMonthTransfer + item.IncentiveWorkingHour + item.PreMonthAnnuelLeaveHour +
                                                   item.AnnuelLeaveWorkingHour + item.PublicHolidayWorkingHour) >= 40 ? 16 : 0;
                else
                    item.WeekendWorkingHour = (int)(item.IncentiveWorkingHour + item.AnnuelLeaveWorkingHour + item.PublicHolidayWorkingHour) >= 40 ? 16 : 0;

                /*her ayın son haftası haft sonu oranı her zaman 0 gelmeli*/
                if (item.WeekNumber == lastWeekNumber)
                    item.WeekendWorkingHour = 0;

                item.IncentiveWorkingHour = Convert.ToDecimal(item.IncentiveWorkingHour.ToString("0.00"));

                var getPersonnelTime = totalTimeList.FirstOrDefault(x => x.RegistrationNo == item.RegistrationNo);

                /*1.haftalık toplam teşvikli çalışma süresi*/
                decimal monthlyincentiveTotalTime = item.IncentiveWorkingHour + item.WeekendWorkingHour;
                /*2.net çalışma süresi*/
                decimal netWorkingTime = businessDayCount * 8 - getPersonnelTime.AnnuelLeaveWorkingHour;
                /*3.teşvikli çalışma oranı*/
                decimal incentiveRate = getPersonnelTime.IncentiveWorkingHour / netWorkingTime;
                /*4.yıllık izin*/
                decimal annualLeave = getPersonnelTime.AnnuelLeaveWorkingHour * incentiveRate;
                /*5.resmi tatil oranı*/
                decimal publicHolidayRate = (publicholidayWeekNumber.Count * 8) * incentiveRate;

                annualLeave /= weekNumberList.Count;
                publicHolidayRate /= weekNumberList.Count;

                /*teşvikli süre toplamı*/
                decimal incentiveTimeTotal = (monthlyincentiveTotalTime + annualLeave + publicHolidayRate) / 8;

                item.SsiWorkingHour = Convert.ToDecimal(incentiveTimeTotal.ToString("0"));
            }

            ssiList.Clear();
            ssiList = _socialSecurity.GetByYearByMonth(reportViewModel.StartDate.Year, reportViewModel.StartDate.Month);
            if (ssiList.Count > 0)
                _socialSecurity.DeleteList(ssiList);

            _socialSecurity.AddList(collect);

            var content = _excelService.SsiExportExcel(collect, "SGK Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SGK Rapor.xlsx");
        }

        [Route("sgk-rapor-indir")]
        public IActionResult SocialSecurityDownload()
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
        [Route("sgk-rapor-indir")]
        public IActionResult SocialSecurityDownload(ReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            List<SocialSecurityDto> ssiList = _socialSecurity.GetByYearByMonth(reportViewModel.StartDate.Year, reportViewModel.StartDate.Month);
            if (ssiList.Count != 0)
            {
                var excelDownload = _excelService.SsiExportExcel(ssiList, "SGK Rapor");

                return File(
                    excelDownload,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SGK Rapor.xlsx");
            }

            AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
            return View(reportViewModel);
        }
        #endregion

        [Route("personel-aktivite-rapor")]
        public IActionResult PersonnelActivityReport()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);

            var projectRelated = new SelectListGroup { Name = "Proje İlişkili" };
            var nonProjectRelated = new SelectListGroup { Name = "Proje İlişkisiz" };
            var timeAwayList = _timeAwayService.GetAll();

            var projectList = _projService.GetAllProjectNameByYear(GetSelectedYear());

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
        [Route("personel-aktivite-rapor")]
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

        [Route("personel-pdks-rapor")]
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
        [Route("personel-pdks-rapor")]
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

        [Route("yonetici-aktivite-rapor")]
        public IActionResult ManagerActivityReport()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);

            var projectRelated = new SelectListGroup { Name = "Proje İlişkili" };
            var nonProjectRelated = new SelectListGroup { Name = "Proje İlişkisiz" };

            var timeAwayList = _timeAwayService.GetAll();
            var projectList = _projService.GetAllProjectNameByYear(GetSelectedYear());
            var personnelList = _infoService.GetAllByYear(GetSelectedYear());

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
        [Route("yonetici-aktivite-rapor")]
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

        [Route("yonetici-pdks-rapor")]
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
        [Route("yonetici-pdks-rapor")]
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

        [Route("uzaktan-calisma-kontrol-rapor")]
        public IActionResult TeleworkingReport()
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
        [Route("uzaktan-calisma-kontrol-rapor")]
        public IActionResult TeleworkingReport(ReportViewModel reportViewModel)
        {
            if (!DateControl(reportViewModel.StartDate, reportViewModel.EndDate))
                return View(reportViewModel);

            List<TeleworkingDto> teleworkingList = _teleworking.GetByYearByMonth(reportViewModel.StartDate.Year, reportViewModel.StartDate.Month);
            if (teleworkingList.Count != 0)
            {
                var excelDownload = _excelService.TeleworkingExportExcel(teleworkingList, "Uzaktan Çalışma Kontrol Rapor");

                return File(
                    excelDownload,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Uzaktan Çalışma Kontrol Rapor.xlsx");
            }

            var personnelEntries = _persEntryService.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);

            if (personnelEntries.Count == 0)
            {
                AddErrorMessage("Aradığınız kritere uygun kayıt bulunamadı.");
                return View(reportViewModel);
            }

            teleworkingList.Clear();
            foreach (var item in personnelEntries)
            {
                TeleworkingDto teleworking = new();

                teleworking.PersonnelFullName = item.PersonnelFullName;
                decimal timediff = Convert.ToDecimal((item.EndDate.Subtract(item.StartDate)).TotalHours);
                if (!string.IsNullOrEmpty(item.ProjectCode))
                    teleworking.ProjectTimeSpend += timediff;

                if (!string.IsNullOrEmpty(item.TimeAwayCode) && item.TimeAwayCode != "12")
                    teleworking.OutsideTimeSpend += timediff;
                else
                    teleworking.TeleworkingTimeSpend += timediff;

                teleworkingList.Add(teleworking);
            }

            var collect = teleworkingList
                .GroupBy(x => new
                {
                    x.PersonnelFullName,
                })
                .Select(x => new TeleworkingDto
                {
                    Year = reportViewModel.StartDate.Year,
                    Month = reportViewModel.StartDate.Month,
                    PersonnelFullName = x.Key.PersonnelFullName,
                    ProjectTimeSpend = x.Sum(x => x.ProjectTimeSpend),
                    OutsideTimeSpend = x.Sum(x => x.OutsideTimeSpend),
                    TeleworkingTimeSpend = x.Sum(x => x.TeleworkingTimeSpend),
                })
                .ToList();

            decimal totalProjectTimeSpend = 0;
            decimal totalOutsideTimeSpend = 0;
            decimal totalTeleworkingTimeSpend = 0;
            foreach (var item in collect)
            {
                totalProjectTimeSpend += item.ProjectTimeSpend;
                totalOutsideTimeSpend += item.OutsideTimeSpend;
                totalTeleworkingTimeSpend += item.TeleworkingTimeSpend;
            }

            decimal totalTimeSpend = totalProjectTimeSpend + totalOutsideTimeSpend;
            if (totalTeleworkingTimeSpend > totalTimeSpend)
            {
                /*uzaktan çalışma süresi toplam diğer zamanlardan daha fazla ise,
                kalan bu zamanları uzaktan çalışma süresi en fazla olandan başlayarak dağıt*/
                decimal remainingtime = totalTeleworkingTimeSpend - totalTimeSpend;
                int numberofTeleworkingPers = collect.Where(x => x.TeleworkingTimeSpend != 0).Count();

                decimal dividedTime = remainingtime / numberofTeleworkingPers;
                collect = collect.OrderByDescending(x => x.TeleworkingTimeSpend).ToList();

                for (int i = 0; i < numberofTeleworkingPers; i++)
                {
                    collect[i].EditedTeleworkingTimeSpend = collect[i].TeleworkingTimeSpend - dividedTime;
                }
            }

            _teleworking.AddList(collect);

            var content = _excelService.TeleworkingExportExcel(collect, "Uzaktan Çalışma Kontrol Rapor");

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Uzaktan Çalışma Kontrol Rapor.xlsx");
        }

        private bool DateControl(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                AddErrorMessage("Başlangıç tarihi bitiş tarihinden büyük olamaz.");
                return false;
            }
            if (startDate.Month != endDate.Month)
            {
                AddErrorMessage("Rapor aralığı 1 ay'dan fazla olamaz.");
                return false;
            }
            return true;
        }

        private decimal GetPreMonthActivities(string regNo, DateTime date)
        {
            DateTime firstDateOfMonth = new(date.Year, date.Month, 1);
            DateTime endDate = firstDateOfMonth.AddDays(-1);

            int days = endDate.DayOfWeek - DayOfWeek.Monday;
            DateTime startDate = endDate.AddDays(days * -1);

            var personnelEntries = _persEntryService.GetAllByMonthByPersonnel(regNo, startDate, endDate);

            decimal preMonthTransfer = 0;
            foreach (var item in personnelEntries)
            {
                if (!string.IsNullOrEmpty(item.ProjectCode) || (Convert.ToInt32(item.TimeAwayCode) >= 1 && Convert.ToInt32(item.TimeAwayCode) <= 12))
                {
                    preMonthTransfer += Convert.ToDecimal(item.EndDate.Subtract(item.StartDate).TotalHours);
                }
            }

            return preMonthTransfer;
        }

        private decimal GetPreMonthAnnuelLeaveHour(string regNo, DateTime date)
        {
            DateTime firstDateOfMonth = new(date.Year, date.Month, 1);
            DateTime endDate = firstDateOfMonth.AddDays(-1);

            int days = endDate.DayOfWeek - DayOfWeek.Monday;
            DateTime startDate = endDate.AddDays(days * -1);

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
            holidays = holidays.OrderBy(x => x.Date).ToList();

            foreach (var item in holidays.Where(x => x.Date.DayOfWeek != DayOfWeek.Saturday && x.Date.DayOfWeek != DayOfWeek.Sunday))
            {
                holidays.RemoveAt(1);
                break;
            }

            return Enumerable.Range(0, (endDate - startDate).Days)
                .Select(a => startDate.AddDays(a))
                .Where(a => a.DayOfWeek != DayOfWeek.Sunday)
                .Where(a => a.DayOfWeek != DayOfWeek.Saturday)
                .Count(a => !holidays.Any(x => x == a));
        }

        private static int GetWeekendDays(DateTime date, int businessDays, List<DateTime> holidays)
        {
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            DateTime endDate = new(date.Year, date.Month, daysInMonth);

            return (int)endDate.Day - businessDays - holidays.Count;
        }

        private static int GetCurrentDayOfWeekNumber(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
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