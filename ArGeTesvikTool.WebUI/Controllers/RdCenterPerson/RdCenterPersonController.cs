using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterPerson;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterPerson
{
    public class RdCenterPersonController : BaseController
    {
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterPersonRewardService _rewardService;

        public RdCenterPersonController(IRdCenterPersonInfoService infoService, IRdCenterPersonRewardService rewardService)
        {
            _infoService = infoService;
            _rewardService = rewardService;
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
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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

        public IActionResult StaffInfo(int year)
        {
            var personInfoList = _infoService.GetAllByYear(year);

            var staffInfoList = personInfoList
                .GroupBy(x => x.PersonPosition)
                .Select(s => new RdCenterPersonStaffInfoDto
                {
                    PersonPosition = s.Key,
                    EducationStatu = s.FirstOrDefault().EducationStatu,
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

            List<RdCenterPersonInfoDto> supportedProgramList = personInfoList.Where(x => (x.EducationStatu.Contains("Lisans") || x.EducationStatu.Contains("Yüksek Lisans") ||
                                                                                          x.EducationStatu.Contains("Doktora")) &&
                                                                                         (x.UniversityDepartmant.Contains("Fizik") || x.UniversityDepartmant.Contains("Kimya") ||
                                                                                          x.UniversityDepartmant.Contains("Biyoloji") || x.UniversityDepartmant.Contains("Matematik")))
                                                                             .ToList();

            RdCenterPersonViewModel supportedProgramViewModel = new()
            {
                PersonInfoList = supportedProgramList
            };

            return View(supportedProgramViewModel);
        }
    }
}
