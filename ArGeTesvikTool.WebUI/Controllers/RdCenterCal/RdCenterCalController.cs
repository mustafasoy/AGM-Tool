﻿using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.RdCenterCal;
using ExcelDataReader;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterCal
{
    public class RdCenterCalController : BaseController
    {
        private readonly IRdCenterCalTimeAwayService _timeAwayService;
        private readonly IRdCenterCalPersAssingService _persAssingService;
        private readonly IRdCenterCalPersonnelEntryService _persEntryService;
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterCalPersAttendanceService _attendanceService;
        private readonly IRdCenterCalPublicHolidayService _holidayService;
        private readonly IRdCenterTechProjectService _projService;

        private readonly IWebHostEnvironment _hostEnvironment;

        public RdCenterCalController(IRdCenterCalTimeAwayService timeAwayService, IRdCenterCalPersAssingService persAssingService, IRdCenterCalPersonnelEntryService persEntryService, IRdCenterPersonInfoService infoService, IRdCenterCalPersAttendanceService attendanceService, IRdCenterCalPublicHolidayService holidayService, IRdCenterTechProjectService projService, IWebHostEnvironment environment, UserManager<AppIdentityUser> userManager) : base(userManager, null, null)
        {
            _timeAwayService = timeAwayService;
            _persAssingService = persAssingService;
            _persEntryService = persEntryService;
            _infoService = infoService;
            _attendanceService = attendanceService;
            _holidayService = holidayService;
            _projService = projService;

            _hostEnvironment = environment;
        }

        #region Personnel Assing CRUD
        public IActionResult PersonnelAssing()
        {
            List<RdCenterTechProjectDto> allProject = _projService.GetAllProjectName();
            List<RdCenterPersonInfoDto> allPersonnel = _infoService.GetAllPersonnel();

            List<SelectListItem> projectCodeList = new();
            foreach (var item in allProject)
            {
                projectCodeList.Add(new SelectListItem
                {
                    Value = item.ProjectCode,
                    Text = item.ProjectName
                });
            }

            List<RdCenterCalPersonnelList> personnelList = new();
            foreach (var item in allPersonnel)
            {
                personnelList.Add(new RdCenterCalPersonnelList {
                    IdentityNumber = item.IdentityNumber,
                    RegistrationNo = item.RegistrationNo,
                    NameSurname = item.NameSurname,
                    PersonPosition = item.PersonPosition.ToString(),
                    WorkType = item.WorkType.ToString()
                });
            }

            RdCenterCalPersAssingViewModel persAssingViewModel = new()
            {
                AllPersonnel = personnelList,
                AllProject = projectCodeList
            };

            return View(persAssingViewModel);
        }

        [HttpPost]
        public IActionResult PersonnelAssing(RdCenterCalPersAssingViewModel persAssingViewModel)
        {
            //var persAssing = _persAssingService.GetById(persAssingViewModel.NewPersAssing.Id);
            //if (persAssing == null)
            //{
            //    persAssingViewModel.NewPersAssing.Year = GetSelectedYear();
            //    persAssingViewModel.NewPersAssing.CreatedDate = DateTime.Now;
            //    persAssingViewModel.NewPersAssing.CreatedUserName = User.Identity.Name;

            //    _persAssingService.Add(persAssingViewModel.NewPersAssing);

            //    AddSuccessMessage("Personele proje bilgisi eklendi.");
            //}
            //else
            //{
            //    persAssingViewModel.NewPersAssing.Id = persAssing.Id;
            //    persAssingViewModel.NewPersAssing.Year = persAssing.Year;
            //    persAssingViewModel.NewPersAssing.CreatedDate = persAssing.CreatedDate;
            //    persAssingViewModel.NewPersAssing.CreatedUserName = persAssing.CreatedUserName;
            //    persAssingViewModel.NewPersAssing.ModifiedDate = DateTime.Now;
            //    persAssingViewModel.NewPersAssing.ModifedUserName = User.Identity.Name;

            //    _persAssingService.Update(persAssingViewModel.NewPersAssing);

            //    AddSuccessMessage("Personele atanan proje bilgisi güncellendi.");
            //}

            return Redirect("PersonnelAssing");
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
                timeAwayViewModel.NewTimeAway.Year = GetSelectedYear();
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

        #region PersonnelEntry CRUD
        public IActionResult PersonnelEntry()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _userManager.FindByIdAsync(userId).Result;
            var persInfo = _infoService.GetByRegNo(currentUser.RegistrationNo);

            string workType = string.Empty;
            if (persInfo != null)
            {
                workType = persInfo.WorkType.ToString();
            }

            var projectRelated = new SelectListGroup { Name = "Proje İlişkili" };
            var nonProjectRelated = new SelectListGroup { Name = "Proje İlişkisiz" };

            var timeAwayList = _timeAwayService.GetAll();
            var projectList = _projService.GetAllProjectName();

            List<SelectListItem> timeAwaySelectList = new();
            foreach (var item in timeAwayList)
            {
                if (workType == "Tam" && Convert.ToInt32(item.TimeAwayCode) == 99)
                {
                    continue;
                }

                if (workType == "Kısmi" && Convert.ToInt32(item.TimeAwayCode) == 98)
                {
                    continue;
                }
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

        public JsonResult GetPersonnelEntry()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var personnelEntry = _persEntryService.GetAllByYearByUserId(GetSelectedYear(),userId)
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
            //bool isOK = CheckEntryTime(personnelViewModel);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = _userManager.FindByIdAsync(userId).Result;

            var persInfo = _infoService.GetByRegNo(currentUser.RegistrationNo);
            string workType = string.Empty;
            string registrationNo = string.Empty;
            if (persInfo != null)
            {
                workType = persInfo.WorkType.ToString();
                registrationNo = persInfo.RegistrationNo;
            }

            var personnelEntry = _persEntryService.GetById(personnelViewModel.Id);

            RdCenterCalPersonnelEntryDto entryDto = new();

            if (personnelEntry == null)
            {
                personnelViewModel.Year = GetSelectedYear();
                personnelViewModel.UserId = userId;
                personnelViewModel.PersonnelFullName = currentUser.Name + " " + currentUser.LastName;
                personnelViewModel.RegistrationNo = registrationNo;
                personnelViewModel.WorkType = workType;
                personnelViewModel.Year = DateTime.Now.Year;
                personnelViewModel.CreatedDate = DateTime.Now;
                personnelViewModel.CreatedUserName = User.Identity.Name;

                entryDto = personnelViewModel.Adapt<RdCenterCalPersonnelEntryDto>();
                _persEntryService.Add(entryDto);

                return Json("201");
            }
            else
            {
                personnelViewModel.Id = personnelEntry.Id;
                personnelViewModel.UserId = userId;
                personnelViewModel.PersonnelFullName = currentUser.Name + " " + currentUser.LastName;
                personnelViewModel.RegistrationNo = registrationNo;
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

                return Json("204");
            }
        }

        public JsonResult DeletePersonnelEntry(int id)
        {
            _persEntryService.Delete(id);

            return Json("200");
        }

        private bool CheckEntryTime(RdCenterCalPersonnelAddViewModel personnelViewModel)
        {
            DateTime startDate = Convert.ToDateTime(personnelViewModel.StartDate + " " + "00:00:00");
            DateTime endDate = Convert.ToDateTime(personnelViewModel.EndDate + " " + "23:59:59");
            var attendanceList = _attendanceService.GetAllByMonthByPersonnelId(personnelViewModel.RegistrationNo, startDate, endDate);

            List<RdCenterCalPersAttendanceDto> newList = DeleteRepeateEvent(attendanceList).ToList();

            /*if attendanceList start with çıkış, delete it. Always attendanceList must start with giriş*/
            var itemRemove = newList.ElementAtOrDefault(0).TerminalName;
            if (itemRemove.Contains("Çıkış"))
            {
                newList.RemoveAt(0);
            }

            string terminalName = string.Empty;
            decimal projectTime = 0;
            decimal timeAwayTime = 0;

            string entryTime = string.Empty;
            string outTime = string.Empty;
            foreach (var item in newList)
            {
                terminalName = item.TerminalName.ToLower().Replace("ç", "c").Replace("ş", "s").Replace("ı", "i");
                if (terminalName.Contains("giris"))
                {
                    entryTime = item.EventTime.ToShortTimeString();
                }
                if (terminalName.Contains("cikis"))
                {
                    outTime = item.EventTime.ToShortTimeString();
                    TimeSpan duration = DateTime.Parse(outTime).Subtract(DateTime.Parse(entryTime));

                    decimal hour = duration.Hours > 0 ? duration.Hours * 60 : 0;
                    decimal minute = duration.Minutes > 0 ? hour + duration.Minutes : hour;

                    if (minute < 30)
                    {
                        projectTime += minute;
                    }

                    if (minute > 30)
                    {
                        timeAwayTime += minute;
                    }
                }

                var personnelEntry = _persEntryService.GetAllPersonnelByCode(personnelViewModel.Id,personnelViewModel.ProjectCode,personnelViewModel.TimeAwayCode);
                
                foreach (var persItem in personnelEntry)
                {
                    TimeSpan duration = DateTime.Parse(persItem.EndDate.ToShortTimeString()).Subtract(DateTime.Parse(persItem.StartDate.ToShortTimeString()));
                    
                    decimal hour = duration.Hours > 0 ? duration.Hours * 60 : 0;
                    decimal minute = duration.Minutes > 0 ? hour + duration.Minutes : hour;

                    if (!string.IsNullOrEmpty(persItem.ProjectCode))
                    {

                    }
                }
            }
            return true;
        }

        private static List<RdCenterCalPersAttendanceDto> DeleteRepeateEvent(List<RdCenterCalPersAttendanceDto> personnelAttendance)
        {
            string terminalName = string.Empty;
            foreach (var item in personnelAttendance.ToList())
            {
                if (item.TerminalName == terminalName)
                {
                    personnelAttendance.Remove(item);
                }

                terminalName = item.TerminalName;
            };

            return personnelAttendance;
        }
        #endregion

        #region ManagerEntry CRUD
        public IActionResult ManagerEntry()
        {
            List<RdCenterCalPersonnelEntryDto> managerList = _persEntryService.GetAllByYear(GetSelectedYear());

            RdCenterCalManagerEntryViewModel managerViewModel = new()
            {
                EntryList = managerList
            };

            return View(managerViewModel);
        }

        public IActionResult ManagerEntryCreate()
        {
            RdCenterCalPersonnelEntryDto managerInfo = new();

            RdCenterCalManagerEntryViewModel managerViewModel = new()
            {
                EntryInfo = managerInfo
            };

            return PartialView("PartialView/ManagerEntryView", managerViewModel);
        }

        public IActionResult ManagerEntryUpdate(int id)
        {
            var entryInfo = _persEntryService.GetById(id);

            RdCenterCalManagerEntryViewModel managerViewModel = new()
            {
                EntryInfo = entryInfo
            };

            return PartialView("PartialView/ManagerEntryView", managerViewModel);
        }

        public IActionResult ManagerEntryDelete(int id)
        {
            _timeAwayService.Delete(id);

            AddSuccessMessage("Zaman bilgisi silindi.");

            return RedirectToAction("ManagerEntry");
        }

        [HttpPost]
        public IActionResult ImportExcel(IFormFile formFile)
        {
            string fileName = Path.Combine(_hostEnvironment.WebRootPath, "files", formFile.FileName);
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            List<RdCenterCalPersonnelEntryDto> entryList = GetExcelList(fileName);

            if (entryList.Count > 0)
            {
                _persEntryService.AddList(entryList);
            }

            if (entryList.Count == 0)
            {
                TempData["ExcelError"] = "Excel dosya degerlerinde hata bulundu. Exceli kontrol ediniz.";
            }

            foreach (var item in entryList)
            {
                if (!string.IsNullOrEmpty(item.ProjectCode) && !string.IsNullOrEmpty(item.TimeAwayCode))
                {
                    TempData["ExcelError"] = "Proje kodu ve Dışarıda geçirilen süre kodu dolu olamaz. Exceli kontrol ediniz.";
                }
                if (string.IsNullOrEmpty(item.PersonnelFullName) || string.IsNullOrEmpty(item.RegistrationNo) ||
                    string.IsNullOrEmpty(item.WorkType) || string.IsNullOrEmpty(item.ProjectName) || string.IsNullOrEmpty(item.TimeAwayName))
                {
                    TempData["ExcelError"] = "Boş alanları doldurunuz.";
                }
            }

            return RedirectToAction("ManagerEntry");
        }

        [HttpPost]
        public IActionResult ExportExcel()
        {
            //build the file path.
            string path = Path.Combine(_hostEnvironment.WebRootPath, "file-template", "Yönetici_Aktivite_Şablon.xlsx");
            string fileName = Path.GetFileName(path);

            //read the file data into byte array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //send the file to download.
            return File(bytes, "application/octet-stream", fileName);
        }

        [HttpPost]
        public IActionResult ManagerEntry(RdCenterCalManagerEntryViewModel managerViewModel)
        {
            var entry = _persEntryService.GetById(managerViewModel.EntryInfo.Id);
            if (entry == null)
            {
                managerViewModel.EntryInfo.Year = GetSelectedYear();
                managerViewModel.EntryInfo.CreatedDate = DateTime.Now;
                managerViewModel.EntryInfo.CreatedUserName = User.Identity.Name;

                _persEntryService.Add(managerViewModel.EntryInfo);

                AddSuccessMessage("Zaman bilgisi eklendi.");

                return RedirectToAction("ManagerEntry");
            }

            managerViewModel.EntryInfo.Id = entry.Id;
            managerViewModel.EntryInfo.Year = entry.Year;
            managerViewModel.EntryInfo.CreatedDate = entry.CreatedDate;
            managerViewModel.EntryInfo.CreatedUserName = entry.CreatedUserName;
            managerViewModel.EntryInfo.ModifiedDate = DateTime.Now;
            managerViewModel.EntryInfo.ModifedUserName = User.Identity.Name;

            _persEntryService.Update(managerViewModel.EntryInfo);

            AddSuccessMessage("Zaman bilgisi güncellendi.");

            return RedirectToAction("ManagerEntry");
        }

        private List<RdCenterCalPersonnelEntryDto> GetExcelList(string fileName)
        {
            List<RdCenterCalPersonnelEntryDto> entryList = new();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (FileStream stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using var reader = ExcelReaderFactory.CreateReader(stream);
                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                if (dataSet.Tables.Count > 0)
                {
                    var rowData = dataSet.Tables[0];

                    for (int i = 0; i < rowData.Rows.Count; i++)
                    {
                        try
                        {
                            entryList.Add(new RdCenterCalPersonnelEntryDto
                            {
                                PersonnelFullName = rowData.Rows[i][0].ToString(),
                                RegistrationNo = rowData.Rows[i][1].ToString(),
                                WorkType = rowData.Rows[i][2].ToString(),
                                ProjectCode = rowData.Rows[i][3].ToString(),
                                ProjectName = rowData.Rows[i][4].ToString(),
                                TimeAwayCode = rowData.Rows[i][5].ToString(),
                                TimeAwayName = rowData.Rows[i][6].ToString(),
                                StartDate = Convert.ToDateTime(rowData.Rows[i][7].ToString()),
                                EndDate = Convert.ToDateTime(rowData.Rows[i][8].ToString()),

                                Year = Convert.ToDateTime(rowData.Rows[i][7].ToString()).Year,
                                CreatedDate = DateTime.Now.Date,
                                CreatedUserName = User.Identity.Name
                            });
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }

            return entryList;
        }
        #endregion

        #region PublicHoliday CRUD
        public IActionResult PublicHoliday()
        {
            int year = GetSelectedYear();
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
                holidayViewModel.NewHoliday.Year = GetSelectedYear();
                holidayViewModel.NewHoliday.Month = holidayViewModel.NewHoliday.StartDate.Month;
                holidayViewModel.NewHoliday.CreatedDate = DateTime.Now;
                holidayViewModel.NewHoliday.CreatedUserName = User.Identity.Name;
                holidayViewModel.NewHoliday.StartDate = new DateTime(holidayViewModel.NewHoliday.StartDate.Year, holidayViewModel.NewHoliday.StartDate.Month, holidayViewModel.NewHoliday.StartDate.Day, 08, 00, 00);
                holidayViewModel.NewHoliday.EndDate = new DateTime(holidayViewModel.NewHoliday.EndDate.Year, holidayViewModel.NewHoliday.EndDate.Month, holidayViewModel.NewHoliday.EndDate.Day, 17, 00, 00);
                _holidayService.Add(holidayViewModel.NewHoliday);

                AddSuccessMessage("Resmi tatil bilgisi eklendi.");
            }
            else
            {
                holidayViewModel.NewHoliday.Id = holiday.Id;
                holidayViewModel.NewHoliday.Year = holiday.Year;
                holidayViewModel.NewHoliday.Month = holiday.Month;
                holidayViewModel.NewHoliday.StartDate = new DateTime(holidayViewModel.NewHoliday.StartDate.Year, holidayViewModel.NewHoliday.StartDate.Month, holidayViewModel.NewHoliday.StartDate.Day, 08, 00, 00);
                holidayViewModel.NewHoliday.EndDate = new DateTime(holidayViewModel.NewHoliday.EndDate.Year, holidayViewModel.NewHoliday.EndDate.Month, holidayViewModel.NewHoliday.EndDate.Day, 17, 00, 00);
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
    }
}
