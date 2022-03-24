using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterPerson;
using ExcelDataReader;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterPerson
{
    public class RdCenterPersonController : BaseController
    {
        private IWebHostEnvironment _hostEnvironment;
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterPersonRewardService _rewardService;
        private readonly IRdCenterPersonTimeAwayService _timeAwayService;

        public RdCenterPersonController(IWebHostEnvironment environment, IRdCenterPersonInfoService infoService, IRdCenterPersonRewardService rewardService, IRdCenterPersonTimeAwayService timeAwayService)
        {
            _hostEnvironment = environment;
            _infoService = infoService;
            _rewardService = rewardService;
            _timeAwayService = timeAwayService;
        }

        #region Person Info CRUD
        public IActionResult PersonInfo(int year)
        {
            List<RdCenterPersonInfoDto> personInfoList = _infoService.GetAllByYear(year);

            RdCenterPersonViewModel personInfoViewModel = new()
            {
                PersonInfoList = personInfoList
            };

            return View(personInfoViewModel);
        }

        public IActionResult PersonInfoCreate()
        {
            RdCenterPersonInfoDto personInfo = new();

            RdCenterPersonViewModel personViewModel = new()
            {
                NewPersonnelInfo = personInfo
            };

            return PartialView("PartialView/PersonelInfoPartialView", personViewModel);
        }

        public IActionResult PersonInfoUpdate(int id)
        {
            var personInfo = _infoService.GetById(id);

            RdCenterPersonViewModel personViewModel = new()
            {
                NewPersonnelInfo = personInfo
            };

            return PartialView("PartialView/PersonelInfoPartialView", personViewModel);
        }

        public IActionResult PersonInfoDelete(int id)
        {
            _infoService.Delete(id);

            AddSuccessMessage("Personel kaydı silindi.");

            return RedirectToAction("PersonelInfo");
        }

        [HttpPost]
        public IActionResult PersonInfo(RdCenterPersonViewModel personViewModel)
        {
            var personInfo = _infoService.GetById(personViewModel.NewPersonnelInfo.Id);
            if (personInfo == null)
            {
                personViewModel.NewPersonnelInfo.CreatedDate = DateTime.Now;
                personViewModel.NewPersonnelInfo.CreatedUserName = User.Identity.Name;

                _infoService.Add(personViewModel.NewPersonnelInfo);

                AddSuccessMessage("Yeni personel kaydı eklendi.");
            }
            else
            {
                personViewModel.NewPersonnelInfo.Id = personInfo.Id;
                personViewModel.NewPersonnelInfo.Year = personInfo.Year;
                personViewModel.NewPersonnelInfo.CreatedDate = personInfo.CreatedDate;
                personViewModel.NewPersonnelInfo.CreatedUserName = personInfo.CreatedUserName;
                personViewModel.NewPersonnelInfo.ModifiedDate = DateTime.Now;
                personViewModel.NewPersonnelInfo.ModifedUserName = User.Identity.Name;

                _infoService.Update(personViewModel.NewPersonnelInfo);

                AddSuccessMessage("Personel kaydı güncellendi.");
            }

            return RedirectToAction("PersonInfo", new { year = 2022 });
        }
        #endregion

        public IActionResult Reward(int year)
        {
            var reward = _rewardService.GetByYear(year);

            RdCenterRewardViewModel rewardViewModel = new()
            {
                Reward = reward
            };

            return View(rewardViewModel);
        }

        [HttpPost]
        public IActionResult Reward(RdCenterRewardViewModel rewardViewModel)
        {
            var reward = _rewardService.GetByYear(rewardViewModel.Reward.Year);
            if (reward == null)
            {
                rewardViewModel.Reward.CreatedDate = DateTime.Now;
                rewardViewModel.Reward.CreatedUserName = User.Identity.Name;

                _rewardService.Add(rewardViewModel.Reward);

                AddSuccessMessage("Performans değerlendirme bilgisi eklendi.");

                return RedirectToAction("Index", "Home");
            }

            rewardViewModel.Reward.Id = reward.Id;
            rewardViewModel.Reward.Year = reward.Year;
            rewardViewModel.Reward.CreatedDate = reward.CreatedDate;
            rewardViewModel.Reward.CreatedUserName = reward.CreatedUserName;
            rewardViewModel.Reward.ModifiedDate = DateTime.Now;
            rewardViewModel.Reward.ModifedUserName = User.Identity.Name;

            _rewardService.Update(rewardViewModel.Reward);

            AddSuccessMessage("Performans değerlendirme bilgisi güncellendi.");

            return RedirectToAction("Index", "Home");
        }

        #region TimeAway CRUD
        public IActionResult TimeAway(int year)
        {
            List<RdCenterPersonTimeAwayDto> timeAwayList = _timeAwayService.GetAllByYear(year);

            RdCenterPersonTimeAwayViewModel timeAwayViewModel = new()
            {
                TimeAwayList = timeAwayList
            };

            return View(timeAwayViewModel);
        }

        public IActionResult TimeAwayCreate()
        {
            RdCenterPersonTimeAwayDto timeAwayInfo = new();

            RdCenterPersonTimeAwayViewModel timeAwayViewModel = new()
            {
                NewTimeInfo = timeAwayInfo
            };

            return PartialView("PartialView/TimeAwayPartialView", timeAwayViewModel);
        }

        public IActionResult TimeAwayUpdate(int id)
        {
            var timeAwayInfo = _timeAwayService.GetById(id);

            RdCenterPersonTimeAwayViewModel timeAwayViewModel = new()
            {
                NewTimeInfo = timeAwayInfo
            };

            return PartialView("PartialView/TimeAwayPartialView", timeAwayViewModel);
        }

        public IActionResult TimeAwayDelete(int id)
        {
            _timeAwayService.Delete(id);

            AddSuccessMessage("Dışarıda geçen zaman bilgisi silindi.");

            return RedirectToAction("TimeAway");
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
            List<RdCenterPersonTimeAwayDto> timeAwayList = GetExcelList(fileName);

            _timeAwayService.AddList(timeAwayList);

            return RedirectToAction("TimeAway");
        }

        [HttpPost]
        public IActionResult ExportExcel()
        {
            //build the file path.
            string path = Path.Combine(_hostEnvironment.WebRootPath, "file-template", "Dışarıda_Geçirilen_Süre_Bildirimi.xlsx");
            string fileName = Path.GetFileName(path);
            //read the file data into byte array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //send the file to download.
            return File(bytes, "application/octet-stream", fileName);
        }

        [HttpPost]
        public IActionResult TimeAway(RdCenterPersonTimeAwayViewModel timeAwayViewModel)
        {
            var timeAway = _timeAwayService.GetById(timeAwayViewModel.NewTimeInfo.Id);
            if (timeAway == null)
            {
                timeAwayViewModel.NewTimeInfo.CreatedDate = DateTime.Now;
                timeAwayViewModel.NewTimeInfo.CreatedUserName = User.Identity.Name;

                _timeAwayService.Add(timeAwayViewModel.NewTimeInfo);

                AddSuccessMessage("Dışarıda geçen zaman bilgisi eklendi.");

                return RedirectToAction("TimeAway");
            }

            timeAwayViewModel.NewTimeInfo.Id = timeAway.Id;
            timeAwayViewModel.NewTimeInfo.Year = timeAway.Year;
            timeAwayViewModel.NewTimeInfo.CreatedDate = timeAway.CreatedDate;
            timeAwayViewModel.NewTimeInfo.CreatedUserName = timeAway.CreatedUserName;
            timeAwayViewModel.NewTimeInfo.ModifiedDate = DateTime.Now;
            timeAwayViewModel.NewTimeInfo.ModifedUserName = User.Identity.Name;

            _timeAwayService.Update(timeAwayViewModel.NewTimeInfo);

            AddSuccessMessage("Dışarıda geçen zaman bilgisi güncellendi.");

            return RedirectToAction("TimeAway");
        }

        private List<RdCenterPersonTimeAwayDto> GetExcelList(string fileName)
        {
            List<RdCenterPersonTimeAwayDto> timeAwayList = new();
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
                        timeAwayList.Add(new RdCenterPersonTimeAwayDto
                        {
                            IdentityNumber = rowData.Rows[i][0].ToString(),
                            ProjectCode = rowData.Rows[i][1].ToString(),
                            ActivityType = (ActivityType)Convert.ToInt32(rowData.Rows[i][2].ToString()),
                            Year = Convert.ToInt32(rowData.Rows[i][3].ToString()),
                            Month = (Month)Convert.ToInt32(rowData.Rows[i][4].ToString()),
                            MonthlyTimeAway = Convert.ToDecimal(rowData.Rows[i][5].ToString()),
                            CreatedDate = DateTime.Now.Date,
                            CreatedUserName = User.Identity.Name
                        });
                    }
                }
            }

            return timeAwayList;
        }
        #endregion

        public IActionResult StaffInfo(int year)
        {
            var personInfoList = _infoService.GetAllByYear(year);

            var staffInfoList = personInfoList
                .GroupBy(x => x.PersonPosition)
                .Select(s => new RdCenterPersonStaffInfoDto
                {
                    PersonPosition = s.Key.ToString(),
                    EducationStatu = s.FirstOrDefault().EducationStatu.ToString(),
                    PersonNumber = s.Count()
                })
                .ToList();

            List<RdCenterPersonStaffInfoDto> staffInfoListView = new();

            foreach (var item in staffInfoList)
            {
                RdCenterPersonStaffInfoDto line = item.Adapt<RdCenterPersonStaffInfoDto>();
                staffInfoListView.Add(line);
            }

            RdCenterPersonStaffInfoViewModel staffInfoViewModel = new()
            {
                StaffInfoList = staffInfoListView
            };

            return View(staffInfoListView);
        }

        public IActionResult SupportedProgram(int year)
        {
            var personInfoList = _infoService.GetAllByYear(year);
            List<RdCenterPersonInfoDto> supportedProgramList = personInfoList.Where(x => new[]
                                                                                              {
                                                                                                EducationStatu.Lisans,
                                                                                                EducationStatu.YuksekLisans,
                                                                                                EducationStatu.Doktora
                                                                                               }
                                                                                               .Contains(x.EducationStatu)
                                                                                               &&
                                                                                              new[]
                                                                                              {
                                                                                                "Fizik",
                                                                                                "Kimya",
                                                                                                "Biyoloji",
                                                                                                "Matematik"
                                                                                               }
                                                                                               .Contains(x.UniversityDepartmant))
                                                                               .ToList();

            RdCenterPersonViewModel supportedProgramViewModel = new()
            {
                PersonInfoList = supportedProgramList
            };

            return View(supportedProgramViewModel);
        }
    }
}
