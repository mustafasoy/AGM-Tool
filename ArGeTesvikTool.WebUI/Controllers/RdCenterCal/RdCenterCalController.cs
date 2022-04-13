using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.Report;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterCal;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterCal
{
    public class RdCenterCalController : BaseController
    {
        private readonly IRdCenterCalPersonnelService _personnelService;
        private readonly IRdCenterCalProjectService _projectService;

        private readonly IRdCenterCalTimeAwayService _timeAwayService;
        private readonly IRdCenterCalPersAssingService _persAssingService;
        private readonly IRdCenterCalPersonnelEntryService _persEntryService;
        private readonly IRdCenterCalManagerEntryService _managerService;
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterCalPublicHolidayService _holidayService;

        private readonly IRdCenterPersonInfoService _persService;
        private readonly IRdCenterTechProjectService _projService;

        public RdCenterCalController(IRdCenterCalPersonnelService personnelService, IRdCenterCalProjectService projectService, IRdCenterCalTimeAwayService timeAwayService, IRdCenterCalPersAssingService persAssingService, IRdCenterCalPersonnelEntryService persEntryService, IRdCenterCalManagerEntryService managerService, IRdCenterPersonInfoService infoService, IRdCenterCalPublicHolidayService holidayService, IRdCenterPersonInfoService persService, IRdCenterTechProjectService projService)
        {
            _personnelService = personnelService;
            _projectService = projectService;
            _timeAwayService = timeAwayService;
            _persAssingService = persAssingService;
            _persEntryService = persEntryService;
            _managerService = managerService;
            _infoService = infoService;
            _holidayService = holidayService;

            _persService = persService;
            _projService = projService;
        }

        #region Personnel CRUD
        public IActionResult PersonnelInfo()
        {
            List<RdCenterCalPersonnelInfoDto> personnelList = _personnelService.GetAll();

            RdCenterCalPersonnelInfoViewModel personnelViewModel = new()
            {
                PersonnelList = personnelList
            };

            return View(personnelViewModel);
        }

        public IActionResult PersonnelCreate()
        {
            RdCenterCalPersonnelInfoDto personnel = new();

            RdCenterCalPersonnelInfoViewModel personnelViewModel = new()
            {
                NewPersonnelInfo = personnel
            };

            return PartialView("PartialView/PersonnelPartialView", personnelViewModel);
        }

        public IActionResult PersonnelUpdate(int id)
        {
            var personnel = _personnelService.GetById(id);

            RdCenterCalPersonnelInfoViewModel personnelViewModel = new()
            {
                NewPersonnelInfo = personnel
            };

            return PartialView("PartialView/PersonnelPartialView", personnelViewModel);
        }

        public IActionResult PersonnelDelete(int id)
        {
            _personnelService.Delete(id);

            AddSuccessMessage("Personel bilgisi silindi.");

            return RedirectToAction("PersonnelInfo");
        }

        [HttpPost]
        public IActionResult PersonnelInfo(RdCenterCalPersonnelInfoViewModel personnelViewModel)
        {
            var personnel = _personnelService.GetById(personnelViewModel.NewPersonnelInfo.Id);
            if (personnel == null)
            {
                personnelViewModel.NewPersonnelInfo.CreatedDate = DateTime.Now;
                personnelViewModel.NewPersonnelInfo.CreatedUserName = User.Identity.Name;

                _personnelService.Add(personnelViewModel.NewPersonnelInfo);

                AddSuccessMessage("Personel bilgisi eklendi.");
            }
            else
            {
                personnelViewModel.NewPersonnelInfo.Id = personnel.Id;
                personnelViewModel.NewPersonnelInfo.Year = personnel.Year;
                personnelViewModel.NewPersonnelInfo.CreatedDate = personnel.CreatedDate;
                personnelViewModel.NewPersonnelInfo.CreatedUserName = personnel.CreatedUserName;
                personnelViewModel.NewPersonnelInfo.ModifiedDate = DateTime.Now;
                personnelViewModel.NewPersonnelInfo.ModifedUserName = User.Identity.Name;

                _personnelService.Update(personnelViewModel.NewPersonnelInfo);

                AddSuccessMessage("Personel bilgisi güncellendi.");
            }

            return Redirect("PersonnelInfo");
        }
        #endregion

        #region Project CRUD
        public IActionResult ProjectInfo()
        {
            List<RdCenterCalProjectInfoDto> projectList = _projectService.GetAll();

            RdCenterCalProjectInfoViewModel projectViewModel = new()
            {
                ProjectList = projectList
            };

            return View(projectViewModel);
        }

        public IActionResult ProjectCreate()
        {
            RdCenterCalProjectInfoDto project = new();

            RdCenterCalProjectInfoViewModel projectViewModel = new()
            {
                NewProjectInfo = project
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectUpdate(int id)
        {
            var project = _projectService.GetById(id);

            RdCenterCalProjectInfoViewModel projectViewModel = new()
            {
                NewProjectInfo = project
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectDelete(int id)
        {
            _projectService.Delete(id);

            AddSuccessMessage("Proje bilgisi silindi.");

            return RedirectToAction("ProjectInfo");
        }

        [HttpPost]
        public IActionResult ProjectInfo(RdCenterCalProjectInfoViewModel projectViewModel)
        {
            var project = _projectService.GetById(projectViewModel.NewProjectInfo.Id);
            if (project == null)
            {
                projectViewModel.NewProjectInfo.CreatedDate = DateTime.Now;
                projectViewModel.NewProjectInfo.CreatedUserName = User.Identity.Name;

                _projectService.Add(projectViewModel.NewProjectInfo);

                AddSuccessMessage("Proje bilgisi eklendi.");
            }
            else
            {
                projectViewModel.NewProjectInfo.Id = project.Id;
                projectViewModel.NewProjectInfo.Year = project.Year;
                projectViewModel.NewProjectInfo.CreatedDate = project.CreatedDate;
                projectViewModel.NewProjectInfo.CreatedUserName = project.CreatedUserName;
                projectViewModel.NewProjectInfo.ModifiedDate = DateTime.Now;
                projectViewModel.NewProjectInfo.ModifedUserName = User.Identity.Name;

                _projectService.Update(projectViewModel.NewProjectInfo);

                AddSuccessMessage("Proje bilgisi güncellendi.");
            }

            return Redirect("ProjectInfo");
        }
        #endregion

        #region TimeAway CRUD
        public IActionResult TimeAway()
        {
            List<RdCenterCalTimeAwayDto> timeAwayList = _timeAwayService.GetAll();

            RdCenterCalTimeAwayViewModel timeAwayViewModel = new()
            {
                TimeAwayList = timeAwayList
            };

            return View(timeAwayViewModel);
        }

        public IActionResult TimeAwayCreate()
        {
            RdCenterCalTimeAwayDto timeAway = new();

            RdCenterCalTimeAwayViewModel timeAwayViewModel = new()
            {
                NewTimeAway = timeAway
            };

            return PartialView("PartialView/TimeAwayPartialView", timeAwayViewModel);
        }

        public IActionResult TimeAwayUpdate(int id)
        {
            var timeAway = _timeAwayService.GetById(id);

            RdCenterCalTimeAwayViewModel timeAwayViewModel = new()
            {
                NewTimeAway = timeAway
            };

            return PartialView("PartialView/TimeAwayPartialView", timeAwayViewModel);
        }

        public IActionResult TimeAwayDelete(int id)
        {
            _timeAwayService.Delete(id);

            AddSuccessMessage("Dışarıda geçen süre bilgisi silindi.");

            return RedirectToAction("TimeAway");
        }

        [HttpPost]
        public IActionResult TimeAway(RdCenterCalTimeAwayViewModel timeAwayViewModel)
        {
            var timeAway = _timeAwayService.GetById(timeAwayViewModel.NewTimeAway.Id);
            if (timeAway == null)
            {
                timeAwayViewModel.NewTimeAway.CreatedDate = DateTime.Now;
                timeAwayViewModel.NewTimeAway.CreatedUserName = User.Identity.Name;

                _timeAwayService.Add(timeAwayViewModel.NewTimeAway);

                AddSuccessMessage("Dışarıda geçen süre bilgisi eklendi.");
            }
            else
            {
                timeAwayViewModel.NewTimeAway.Id = timeAway.Id;
                timeAwayViewModel.NewTimeAway.Year = timeAway.Year;
                timeAwayViewModel.NewTimeAway.CreatedDate = timeAway.CreatedDate;
                timeAwayViewModel.NewTimeAway.CreatedUserName = timeAway.CreatedUserName;
                timeAwayViewModel.NewTimeAway.ModifiedDate = DateTime.Now;
                timeAwayViewModel.NewTimeAway.ModifedUserName = User.Identity.Name;

                _timeAwayService.Update(timeAwayViewModel.NewTimeAway);

                AddSuccessMessage("Dışarıda geçen süre bilgisi güncellendi.");
            }

            return Redirect("TimeAway");
        }
        #endregion

        #region Personnel Assing CRUD
        public IActionResult PersonnelAssing()
        {
            List<RdCenterCalPersAssingDto> persAssingList = _persAssingService.GetAll();

            RdCenterCalPersAssingViewModel persAssingViewModel = new()
            {
                PersAssingList = persAssingList
            };

            return View(persAssingViewModel);
        }

        public IActionResult PersonnelAssingCreate()
        {
            RdCenterCalPersAssingDto persAssing = new();

            RdCenterCalPersAssingViewModel persAssingViewModel = new()
            {
                NewPersAssing = persAssing
            };

            return PartialView("PartialView/PersAssingPartialView", persAssingViewModel);
        }

        public IActionResult PersonnelAssingUpdate(int id)
        {
            var persAssing = _persAssingService.GetById(id);

            RdCenterCalPersAssingViewModel persAssingViewModel = new()
            {
                NewPersAssing = persAssing
            };

            return PartialView("PartialView/PersAssingPartialView", persAssingViewModel);
        }

        public IActionResult PersonnelAssingDelete(int id)
        {
            _persAssingService.Delete(id);

            AddSuccessMessage("Personele atanan proje silindi.");

            return RedirectToAction("PersonnelAssing");
        }

        [HttpPost]
        public IActionResult PersonnelAssing(RdCenterCalPersAssingViewModel persAssingViewModel)
        {
            var persAssing = _persAssingService.GetById(persAssingViewModel.NewPersAssing.Id);
            if (persAssing == null)
            {
                persAssingViewModel.NewPersAssing.CreatedDate = DateTime.Now;
                persAssingViewModel.NewPersAssing.CreatedUserName = User.Identity.Name;

                _persAssingService.Add(persAssingViewModel.NewPersAssing);

                AddSuccessMessage("Personele proje bilgisi eklendi.");
            }
            else
            {
                persAssingViewModel.NewPersAssing.Id = persAssing.Id;
                persAssingViewModel.NewPersAssing.Year = persAssing.Year;
                persAssingViewModel.NewPersAssing.CreatedDate = persAssing.CreatedDate;
                persAssingViewModel.NewPersAssing.CreatedUserName = persAssing.CreatedUserName;
                persAssingViewModel.NewPersAssing.ModifiedDate = DateTime.Now;
                persAssingViewModel.NewPersAssing.ModifedUserName = User.Identity.Name;

                _persAssingService.Update(persAssingViewModel.NewPersAssing);

                AddSuccessMessage("Personele atanan proje bilgisi güncellendi.");
            }

            return Redirect("PersonnelAssing");
        }
        #endregion

        #region PersonnelEntry CRUD
        public IActionResult PersonnelEntry()
        {
            var projectRelated = new SelectListGroup { Name = "Proje İlişkili" };
            var nonProjectRelated = new SelectListGroup { Name = "Proje İlişkisiz" };
            //var projectList = _projectService.GetAll();
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

            RdCenterCalPersonnelEntryViewModel personnelEntryViewModel = new()
            {
                ProjectList = projectList.Select(x => new SelectListItem
                {
                    Value = x.ProjectCode,
                    Text = x.ProjectName,
                }).ToList(),
                TimeAwayList = timeAwaySelectList
            };

            return View(personnelEntryViewModel);
        }

        public JsonResult GetPersonnelEntry(int year)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var personnelEntry = _persEntryService.GetAll(2022)
                .Select(x => new RdCenterCalPersonnelAddViewModel()
                {
                    Id = x.Id,
                    UserId = userId,
                    ProjectCode = x.ProjectCode,
                    ProjectName = x.ProjectName,
                    TimeAwayCode = x.TimeAwayCode,
                    TimeAwayName = x.TimeAwayName,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                });

            return Json(personnelEntry);
        }

        [HttpPost]
        public JsonResult CreateorUpdatePersonnelEntry(RdCenterCalPersonnelAddViewModel personnelViewModel)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = _userManager.FindByIdAsync(userId).Result;

            string regNo = currentUser.RegistrationNo;
            string workType = _infoService.GetByRegNo(regNo).RegistrationNo;


            var personnelEntry = _persEntryService.GetById(personnelViewModel.Id);

            RdCenterCalPersonnelEntryDto entryDto = new();

            if (personnelEntry == null)
            {
                personnelViewModel.UserId = userId;
                personnelViewModel.PersonnelFullName = currentUser.Name + " " + currentUser.LastName;
                personnelViewModel.RegistrationNo = regNo;
                personnelViewModel.WorkType = workType;
                personnelViewModel.Year = DateTime.Now.Year;
                personnelViewModel.CreatedDate = DateTime.Now;
                personnelViewModel.CreatedUserName = User.Identity.Name;

                entryDto = personnelViewModel.Adapt<RdCenterCalPersonnelEntryDto>();
                _persEntryService.Add(entryDto);
            }
            else
            {
                personnelViewModel.Id = personnelEntry.Id;
                personnelViewModel.UserId = userId;
                personnelViewModel.PersonnelFullName = currentUser.Name + " " + currentUser.LastName;
                personnelViewModel.RegistrationNo = regNo;
                personnelViewModel.WorkType = workType;
                personnelViewModel.Year = personnelEntry.Year;
                personnelViewModel.ProjectName = personnelEntry.ProjectName;
                personnelViewModel.TimeAwayName = personnelEntry.TimeAwayName;
                personnelViewModel.StartDate = personnelViewModel.StartDate;
                personnelViewModel.EndDate = personnelViewModel.EndDate;
                personnelViewModel.CreatedDate = personnelEntry.CreatedDate;
                personnelViewModel.CreatedUserName = personnelEntry.CreatedUserName;
                personnelViewModel.ModifiedDate = DateTime.Now;
                personnelViewModel.ModifedUserName = User.Identity.Name;

                entryDto = personnelViewModel.Adapt<RdCenterCalPersonnelEntryDto>();

                _persEntryService.Update(entryDto);
            }

            return Json("200");
        }

        public JsonResult DeletePersonnelEntry(int id)
        {
            _persEntryService.Delete(id);

            return Json("200");
        }
        #endregion

        #region ManagerEntry CRUD
        public IActionResult ManagerEntry()
        {
            return View();
        }
        #endregion

        public IActionResult Calculation()
        {

            return View();
        }

        #region PublicHoliday CRUD
        public IActionResult PublicHoliday(int year)
        {
            var yearList = _holidayService.GetAll();

            int duplicateYear = 0;
            foreach (var item in yearList.ToList())
            {
                if (item.Year == year)
                {
                    yearList.Remove(item);
                }

                if (item.Year == duplicateYear)
                    yearList.Remove(item);

                duplicateYear = item.Year;
            }

            List<RdCenterCalPublicHolidayDto> holidayList = _holidayService.GetAll();

            RdCenterCalPublicHolidayViewModel holidayViewModel = new()
            {
                HolidayList = holidayList,
                YearList = yearList.Select(x => new SelectListItem
                {
                    Value = x.Year.ToString(),
                    Text = x.Year.ToString()
                }).ToList(),
            };

            ViewBag.Year = year;

            return View(holidayViewModel);
        }

        public IActionResult HolidayCreate()
        {
            RdCenterCalPublicHolidayDto holiday = new();

            RdCenterCalPublicHolidayViewModel holidayViewModel = new()
            {
                NewHoliday = holiday
            };

            return PartialView("PartialView/HolidayPartialView", holidayViewModel);
        }

        public IActionResult HolidayUpdate(int id)
        {
            var holiday = _holidayService.GetById(id);

            RdCenterCalPublicHolidayViewModel holidayViewModel = new()
            {
                NewHoliday = holiday
            };

            return PartialView("PartialView/HolidayPartialView", holidayViewModel);
        }

        public IActionResult HolidayDelete(int id)
        {
            _holidayService.Delete(id);

            AddSuccessMessage("Resmi tatil bilgisi silindi.");

            return RedirectToAction("PublicHoliday");
        }

        [HttpPost]
        public IActionResult PublicHoliday(RdCenterCalPublicHolidayViewModel holidayViewModel)
        {
            var holiday = _holidayService.GetById(holidayViewModel.NewHoliday.Id);
            if (holiday == null)
            {
                holidayViewModel.NewHoliday.Month = holidayViewModel.NewHoliday.StartDate.Month;
                holidayViewModel.NewHoliday.CreatedDate = DateTime.Now;
                holidayViewModel.NewHoliday.CreatedUserName = User.Identity.Name;

                _holidayService.Add(holidayViewModel.NewHoliday);

                AddSuccessMessage("Resmi tatil bilgisi eklendi.");
            }
            else
            {
                holidayViewModel.NewHoliday.Id = holiday.Id;
                holidayViewModel.NewHoliday.Year = holiday.Year;
                holidayViewModel.NewHoliday.Month = holiday.Month;
                holidayViewModel.NewHoliday.CreatedDate = holiday.CreatedDate;
                holidayViewModel.NewHoliday.CreatedUserName = holiday.CreatedUserName;
                holidayViewModel.NewHoliday.ModifiedDate = DateTime.Now;
                holidayViewModel.NewHoliday.ModifedUserName = User.Identity.Name;

                _holidayService.Update(holidayViewModel.NewHoliday);

                AddSuccessMessage("Resmi tatil bilgisi güncellendi.");
            }

            return Redirect("PublicHoliday");
        }
        #endregion

        public IActionResult Income()
        {
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);
            RdCenterCalIncomeReportViewModel reportViewModel = new()
            {
                StartDate = startDate,
                EndDate = startDate.AddMonths(1).AddDays(-1)
            };

            return View(reportViewModel);
        }

        [HttpPost]
        public void Income(RdCenterCalIncomeReportViewModel reportViewModel)
        {
            var personnelEntries = _persEntryService.GetAllByMonth(reportViewModel.StartDate, reportViewModel.EndDate);

            List<IncomeDto> incomeList = new();
            foreach (var item in personnelEntries)
            {
                IncomeDto newIncome = new();
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
                if (item.WorkType == "Tam Zamanlı" && item.TimeAwayCode == "99")
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
            List<RdCenterCalPublicHolidayDto> publicholidays = _holidayService.GetAllByYear(reportViewModel.StartDate.Year);
            List<DateTime> publicholidayList = new();
            foreach (var item in publicholidays)
            {
                int timeDiff = Convert.ToInt32(item.EndDate.Subtract(item.StartDate).TotalHours);
                for (int i = 0; i < timeDiff; i++)
                {
                    publicholidayList.Add(item.StartDate.AddDays(i));
                }
            }
            int businessDayCount = GetBusinessDays(reportViewModel.StartDate, reportViewModel.EndDate, holidayList);
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
            DateTime firstMonthDay = new(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > firstMonthDay)
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
