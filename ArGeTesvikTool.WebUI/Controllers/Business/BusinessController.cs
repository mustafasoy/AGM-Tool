using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.WebUI.Models.Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Controllers.Business
{
    public class BusinessController : Controller
    {
        private IBusinessInfoService _businessInfoService;
        private IBusinessIntroService _businessIntroService;
        private IGroupInfoService _groupInfoService;

        public BusinessController(IBusinessInfoService businessInfoService, IBusinessIntroService businessIntroService, IGroupInfoService groupInfoService)
        {
            _businessInfoService = businessInfoService;
            _businessIntroService = businessIntroService;
            _groupInfoService = groupInfoService;
        }

        public IActionResult Info(int year)
        {
            var info = _businessInfoService.GetByYear(year);

            BusinessInfoViewModel infoViewModel = new()
            {
                BusinessInfo = info
            };

            return View(infoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Info(BusinessInfoViewModel infoViewModel)
        {
            if (ModelState.IsValid)
            {
                _businessInfoService.Add(infoViewModel.BusinessInfo);
                TempData["SuccessMessage"] = "Veriler eklendi...";
                return RedirectToAction("Index", "Home");
            }

            return View(infoViewModel);
        }

        public IActionResult Intro(int year)
        {
            var intro = _businessIntroService.GetByYear(year);

            BusinessIntroViewModel introViewModel = new()
            {
                BusinessIntro = intro
            };

            return View(introViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Intro(BusinessIntroViewModel introViewModel)
        {
            if (ModelState.IsValid)
            {
                _businessIntroService.Add(introViewModel.BusinessIntro);
                TempData["SuccessMessage"] = "Veriler eklendi...";
                return RedirectToAction("Index", "Home");
            }

            return View(introViewModel);
        }

        public IActionResult GroupInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GroupInfo(GroupInfoViewModel groupInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                _groupInfoService.Add(groupInfoViewModel.GroupInfo);
                TempData["SuccessMessage"] = "Veriler eklendi...";
                return RedirectToAction("Index", "Home");
            }

            return View(groupInfoViewModel);
        }

        public IActionResult Shareholder()
        {
            List<ShareholdersDto> shareholderList = new();

            shareholderList.Add(new ShareholdersDto
            {
                CompanyName = "Borusan Holding AŞ",
                Origin = "Türkiye",
                Share = 36,
                ShareAmount = 100,
            });

            shareholderList.Add(new ShareholdersDto
            {
                CompanyName = "Borusan Yatırım Paz AŞ",
                Origin = "Türkiye",
                Share = 11,
                ShareAmount = 300,
            });

            ShareholderViewModel shareholderViewModel = new()
            {
                Shareholder = shareholderList
            };

            return View(shareholderViewModel);
        }

        public IActionResult PersonnelDistribution()
        {
            List<PersonnelDistributionDto> personnelDistribution = new();

            personnelDistribution.Add(new PersonnelDistributionDto
            {
                CompanyUnit = "İdari",
                PostDoctoral = 0,
                Doctoral = 0,
                MasterDegree = 69,
                BachelorDegree = 525,
                AssociateDegree = 210,
                HighSchool = 310,
                Total = 1114
            });

            personnelDistribution.Add(new PersonnelDistributionDto
            {
                CompanyUnit = "Mali",
                PostDoctoral = 0,
                Doctoral = 0,
                MasterDegree = 8,
                BachelorDegree = 52,
                AssociateDegree = 9,
                HighSchool = 6,
                Total = 75
            });

            PersonnelDistributionViewModel personnelDistributionViewModel = new()
            {
                PersonnelDistribution = personnelDistribution
            };

            return View(personnelDistributionViewModel);
        }

        public IActionResult FinancialInfo()
        {
            //List<FinancialInfoDto> financialInfo = new();

            //financialInfo.Add(new FinancialInfoDto
            //{
            //    NetSales = 2600,
            //    TotalAsset = 1449,
            //    SortTermLoan = 966,
            //    LongTermLoan = 403,
            //    DomesticSales = 2618,
            //    ExportSales = 380,
            //    GrossSales = 2618,
            //    RDExpenditure = 12746,
            //    AcquisitionTurnover = 434
            //});

            //financialInfo.Add(new FinancialInfoDto
            //{
            //    NetSales = 2600,
            //    TotalAsset = 1449,
            //    SortTermLoan = 966,
            //    LongTermLoan = 403,
            //    DomesticSales = 2618,
            //    ExportSales = 380,
            //    GrossSales = 2618,
            //    RDExpenditure = 12746,
            //    AcquisitionTurnover = 434
            //});

            //FinancialInfoViewModel financialInfoViewModel = new()
            //{
            //    FinancialInfo = financialInfo
            //};

            //return View(financialInfoViewModel);

            return View();
        }
    }
}
