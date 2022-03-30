using ArGeTesvikTool.Business.Abstract.Index;
using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.Index;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.Index;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.WebUI.Controllers.Index
{
    public class IndexController : BaseController
    {
        private readonly INewDataService _newDataService;
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterAmountService _amountService;

        public IndexController(IRdCenterPersonInfoService infoService, IRdCenterAmountService amountService, INewDataService newDataService)
        {
            _infoService = infoService;
            _amountService = amountService;
            _newDataService = newDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewData(int year)
        {
            var newData = _newDataService.GetByYear(year);

            NewDataViewModel newDataViewModel = new()
            {
                NewData = newData
            };

            return View(newDataViewModel);
        }

        [HttpPost]
        public IActionResult NewData(NewDataViewModel newDataViewModel)
        {
            var newData = _newDataService.GetByYear(newDataViewModel.NewData.Year);
            if (newData == null)
            {
                newDataViewModel.NewData.CreatedDate = DateTime.Now;
                newDataViewModel.NewData.CreatedUserName = User.Identity.Name;

                _newDataService.Add(newDataViewModel.NewData);

                AddSuccessMessage("Bilgiler eklendi.");
                return RedirectToAction("Index", "Home");
            }

            newDataViewModel.NewData.Id = newData.Id;
            newDataViewModel.NewData.Year = newData.Year;
            newDataViewModel.NewData.CreatedDate = newData.CreatedDate;
            newDataViewModel.NewData.CreatedUserName = newData.CreatedUserName;
            newDataViewModel.NewData.ModifiedDate = DateTime.Now;
            newDataViewModel.NewData.ModifedUserName = User.Identity.Name;

            _newDataService.Update(newDataViewModel.NewData);

            AddSuccessMessage("Bilgiler güncellendi.");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Employment(int year)
        {
            List<RdCenterPersonInfoDto> personInfoList = _infoService.GetAllByYear(year);

            EmploymentDto employmentData = new()
            {
                GraduateDoctoralNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.Doktora).Count(),
                GraduateMasterDegreeNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.YuksekLisans).Count(),
                GraduateBachelorDegreeNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.Lisans).Count(),
                CurrentDoctoralNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.DoktoraOgrenci).Count(),
                CurrentMasterDegreeNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.YuksekLisansOgrenci).Count(),
                //GraduateBasicScienceNumber = personInfoList.Where(x => x.EducationStatu == "Yüksek Lisans(Öğrenci)").Count(),
                //TechnicianNumber = personInfoList.Where(x => x.EducationStatu == "Teknisyen").Count(),
                //TotalResearcherNumber = personInfoList.Where(x => x.EducationStatu == "Teknisyen").Count(),
                TotalResearcherNumber = personInfoList.Count,
            };

            EmploymentViewModel indexInfoViewModel = new()
            {
                EmploymentInfo = employmentData
            };

            return View(indexInfoViewModel);

        }

        public IActionResult SpendingIntensity(int year)
        {
            List<RdCenterAmountDto> amountList = _amountService.GetAllByYear(year);

            SpendingIntensityDto spendingIntensity = new()
            {
                CashSupport = amountList.Select(x => Convert.ToDecimal(x.CashSupport)).Sum().ToString(),
                PreviousYearCashSupport = amountList.Select(x => Convert.ToDecimal(x.CashSupport)).Sum().ToString(),
                DesignExpense = amountList.Select(x => Convert.ToDecimal(x.DesignExpense)).Sum().ToString()
            };

            SpendingIntensityViewModel spendingIntensityInfoViewModel = new()
            {
                SpendingIntensityInfo = spendingIntensity
            };

            return View(spendingIntensityInfoViewModel);
        }

        public IActionResult Cooperation()
        {
            return View();
        }

        public IActionResult Commercialization()
        {
            return View();
        }

        public IActionResult PropertyCompetence()
        {
            return View();
        }

        public IActionResult Other()
        {
            return View();
        }
    }
}
