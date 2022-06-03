using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterPerson;
using ExcelDataReader;
using Mapster;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class RdCenterPersonController : BaseController
    {
        private readonly IWebHostEnvironment _hostEnvironment;
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
        [Route("calisan-personel")]
        public IActionResult PersonInfo()
        {

            List<RdCenterPersonInfoDto> personInfoList = _infoService.GetAllByYear(GetSelectedYear());

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

            ViewBag.Country = personInfo.CountryCode;

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
        [Route("calisan-personel")]
        public IActionResult PersonInfo(RdCenterPersonViewModel personViewModel)
        {
            bool isCheck = CheckPersonnelExists(personViewModel.NewPersonnelInfo.IdentityNumber);
            if (isCheck)
            {
                List<RdCenterPersonInfoDto> personInfoList = _infoService.GetAllByYear(GetSelectedYear());
                RdCenterPersonViewModel personInfoViewModel = new()
                {
                    PersonInfoList = personInfoList
                };

                return View(personInfoViewModel);
            }

            personViewModel.NewPersonnelInfo.Id = personViewModel.NewPersonnelInfo.Id;
            personViewModel.NewPersonnelInfo.Year = personViewModel.NewPersonnelInfo.Year;
            personViewModel.NewPersonnelInfo.CreatedDate = personViewModel.NewPersonnelInfo.CreatedDate;
            personViewModel.NewPersonnelInfo.CreatedUserName = personViewModel.NewPersonnelInfo.CreatedUserName;
            personViewModel.NewPersonnelInfo.ModifiedDate = DateTime.Now;
            personViewModel.NewPersonnelInfo.ModifedUserName = User.Identity.Name;

            _infoService.Update(personViewModel.NewPersonnelInfo);

            AddSuccessMessage("Personel kaydı güncellendi.");

            return RedirectToAction("PersonInfo");
        }

        private bool CheckPersonnelExists(string identityNumber)
        {
            //check personnel info, if exists give error.
            var checkPersonInfo = _infoService.GetByIdentityNo(identityNumber);
            if (checkPersonInfo != null)
            {
                AddErrorMessage("Personel daha önce kaydedilmiş.");
                return true;
            }

            return false;
        }
        #endregion

        [Route("performans-odul")]
        public IActionResult Reward()
        {
            var reward = _rewardService.GetByYear(GetSelectedYear());

            RdCenterRewardViewModel rewardViewModel = new()
            {
                Reward = reward
            };

            return View(rewardViewModel);
        }

        [HttpPost]
        [Route("performans-odul")]
        public IActionResult Reward(RdCenterRewardViewModel rewardViewModel)
        {
            var reward = _rewardService.GetByYear(rewardViewModel.Reward.Year);
            if (reward == null)
            {
                rewardViewModel.Reward.Year = GetSelectedYear();
                rewardViewModel.Reward.CreatedDate = DateTime.Now;
                rewardViewModel.Reward.CreatedUserName = User.Identity.Name;

                _rewardService.Add(rewardViewModel.Reward);

                AddSuccessMessage("Performans değerlendirme bilgisi eklendi.");
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
        [Route("disarida-gecen-sure-tanımla")]
        public IActionResult TimeAway()
        {
            List<RdCenterPersonTimeAwayDto> timeAwayList = _timeAwayService.GetAllByYear(GetSelectedYear());

            RdCenterPersonTimeAwayViewModel timeAwayViewModel = new()
            {
                TimeAwayList = timeAwayList,
            };

            return View(timeAwayViewModel);
        }

        public IActionResult TimeAwayCreate()
        {
            RdCenterPersonTimeAwayDto timeAwayInfo = new();

            timeAwayInfo.Year = GetSelectedYear();
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
        [Route("disarida-gecen-sure-tanımla")]
        public IActionResult ImportExcel(IFormFile formFile)
        {
            string fileName = Path.Combine(_hostEnvironment.WebRootPath, "files", formFile.FileName);
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            List<RdCenterPersonTimeAwayDto> timeAwayList = GetExcelList(fileName);

            if (timeAwayList.Count > 0)
            {
                _timeAwayService.AddList(timeAwayList);
            }

            if (timeAwayList.Count == 0)
            {
                TempData["ExcelError"] = "Excel dosya degerlerinde hata bulundu. Exceli kontrol ediniz.";
            }

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
                timeAwayViewModel.NewTimeInfo.Year = GetSelectedYear();
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
                        try
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
                        catch (Exception)
                        {

                        }
                    }
                }
            }

            return timeAwayList;
        }
        #endregion

        [Route("personel-bilgi")]
        public IActionResult StaffInfo()
        {
            var personInfoList = _infoService.GetAllByYear(GetSelectedYear());

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

        [Route("destelenecek-program")]
        public IActionResult SupportedProgram()
        {
            var personInfoList = _infoService.GetAllByYear(GetSelectedYear());
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
