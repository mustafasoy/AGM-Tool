using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Controllers.Business
{
    public class BusinessController : BaseController
    {
        private readonly IBusinessContactService _contactService;
        private readonly IBusinessInfoService _infoService;
        private readonly IBusinessIntroService _introService;
        private readonly IGroupInfoService _groupInfoService;
        private readonly IShareholderService _shareholderService;

        public BusinessController(IBusinessContactService contactService, IBusinessInfoService infoService, IBusinessIntroService introService, IGroupInfoService groupInfoService, IShareholderService shareholderService)
        {
            _contactService = contactService;
            _infoService = infoService;
            _introService = introService;
            _groupInfoService = groupInfoService;
            _shareholderService = shareholderService;
        }

        [HttpGet]
        public IActionResult Contact(int id)
        {
            var contact = _contactService.GetByYear(id);

            BusinessContactViewModel contactViewModel = new()
            {
                BusinessContact = contact
            };

            return View(contactViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(BusinessContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var validate = ValidatorTool.Validate(new BusinessContactValidator(), contactViewModel.BusinessContact);
                if (validate.IsValid)
                {
                    //get data exist or not.
                    var contact = _contactService.GetByYear(contactViewModel.BusinessContact.Year);
                    if (contact == null)
                    {
                        contactViewModel.BusinessContact.CreatedDate = DateTime.Now;
                        contactViewModel.BusinessContact.CreatedUserName = User.Identity.Name;

                        _contactService.Add(contactViewModel.BusinessContact);

                        TempData["SuccessMessage"] = "Veriler eklendi...";
                        return RedirectToAction("Index", "Home");
                    }

                    contactViewModel.BusinessContact.Id = contact.Id;
                    contactViewModel.BusinessContact.Year = contact.Year;
                    contactViewModel.BusinessContact.CreatedDate = contact.CreatedDate;
                    contactViewModel.BusinessContact.CreatedUserName = contact.CreatedUserName;
                    contactViewModel.BusinessContact.ModifiedDate = DateTime.Now;
                    contactViewModel.BusinessContact.ModifedUserName = User.Identity.Name;

                    _contactService.Update(contactViewModel.BusinessContact);

                    TempData["SuccessMessage"] = "Veriler güncellendi...";
                    return RedirectToAction("Index", "Home");
                }

                AddValidatorError(validate);
            }

            return View(contactViewModel);
        }

        public IActionResult Info(int id)
        {
            var info = _infoService.GetByYear(id);

            if (info != null)
            {
                ViewBag.City = info.City;
            }

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
                var validate = ValidatorTool.Validate(new BusinessInfoValidator(), infoViewModel.BusinessInfo);
                if (validate.IsValid)
                {
                    var info = _infoService.GetByYear(infoViewModel.BusinessInfo.Year);
                    if (info == null)
                    {
                        infoViewModel.BusinessInfo.CreatedDate = DateTime.Now;
                        infoViewModel.BusinessInfo.CreatedUserName = User.Identity.Name;

                        _infoService.Add(infoViewModel.BusinessInfo);

                        TempData["SuccessMessage"] = "Veriler eklendi...";
                        return RedirectToAction("Index", "Home");
                    }

                    infoViewModel.BusinessInfo.Id = info.Id;
                    infoViewModel.BusinessInfo.Year = info.Year;
                    infoViewModel.BusinessInfo.CreatedDate = info.CreatedDate;
                    infoViewModel.BusinessInfo.CreatedUserName = info.CreatedUserName;
                    infoViewModel.BusinessInfo.ModifiedDate = DateTime.Now;
                    infoViewModel.BusinessInfo.ModifedUserName = User.Identity.Name;

                    _infoService.Update(infoViewModel.BusinessInfo);
                    TempData["SuccessMessage"] = "Veriler güncellendi...";
                    return RedirectToAction("Index", "Home");
                }

                AddValidatorError(validate);
            }

            return View(infoViewModel);
        }

        public IActionResult Intro(int id)
        {
            var intro = _introService.GetByYear(id);

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
                var intro = _introService.GetByYear(introViewModel.BusinessIntro.Year);
                if (intro == null)
                {
                    introViewModel.BusinessIntro.CreatedDate = DateTime.Now;
                    introViewModel.BusinessIntro.CreatedUserName = User.Identity.Name;
                    _introService.Add(introViewModel.BusinessIntro);

                    TempData["SuccessMessage"] = "Veriler eklendi...";

                    return RedirectToAction("Index", "Home");
                }

                introViewModel.BusinessIntro.Id = intro.Id;
                introViewModel.BusinessIntro.Year = intro.Year;
                introViewModel.BusinessIntro.CreatedDate = intro.CreatedDate;
                introViewModel.BusinessIntro.CreatedUserName = intro.CreatedUserName;
                introViewModel.BusinessIntro.ModifiedDate = DateTime.Now;
                introViewModel.BusinessIntro.ModifedUserName = User.Identity.Name;

                _introService.Update(introViewModel.BusinessIntro);
                TempData["SuccessMessage"] = "Veriler güncellendi...";
                return RedirectToAction("Index", "Home");
            }

            return View(introViewModel);
        }

        public IActionResult GroupInfo(int id)
        {
            var groupInfo = _groupInfoService.GetByYear(id);
            GroupInfoViewModel groupViewModel = new()
            {
                GroupInfo = groupInfo
            };            return View(groupViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GroupInfo(GroupInfoViewModel groupInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                var groupInfo = _groupInfoService.GetByYear(groupInfoViewModel.GroupInfo.Year);
                if (groupInfo == null)
                {
                    groupInfoViewModel.GroupInfo.CreatedDate = DateTime.Now;
                    groupInfoViewModel.GroupInfo.CreatedUserName = User.Identity.Name;

                    _groupInfoService.Add(groupInfoViewModel.GroupInfo);
                    TempData["SuccessMessage"] = "Veriler eklendi...";
                    return RedirectToAction("Index", "Home");
                }

                groupInfoViewModel.GroupInfo.Id = groupInfo.Id;
                groupInfoViewModel.GroupInfo.Year = groupInfo.Year;
                groupInfoViewModel.GroupInfo.CreatedDate = groupInfo.CreatedDate;
                groupInfoViewModel.GroupInfo.CreatedUserName = groupInfo.CreatedUserName;
                groupInfoViewModel.GroupInfo.ModifiedDate = DateTime.Now;
                groupInfoViewModel.GroupInfo.ModifedUserName = User.Identity.Name;

                _groupInfoService.Update(groupInfoViewModel.GroupInfo);
                TempData["SuccessMessage"] = "Veriler güncellendi...";
                return RedirectToAction("Index", "Home");

            }

            return View(groupInfoViewModel);
        }

        #region Shareholder CRUD
        public IActionResult Shareholder(int id)
        {
            List<ShareholdersDto> shareholderList = _shareholderService.GetAll();

            ShareholderViewModel shareholderViewModel = new()
            {
                Shareholder = shareholderList
            };

            return View(shareholderViewModel);
        }

        public IActionResult ShareholderCreate()
        {
            ShareholdersDto shareholder = new();

            ShareholderViewModel shareholderViewModel = new()
            {
                NewShareholder = shareholder
            };

            return PartialView("PartialView/ShareholderPartialView", shareholderViewModel);
        }

        public IActionResult ShareholderUpdate(int id)
        {
            var shareholder = _shareholderService.GetById(id);

            ShareholderViewModel shareholderViewModel = new()
            {
                NewShareholder = shareholder
            };

            ViewBag.SuccessMessage = "Veri güncellendi...";
            return PartialView("PartialView/ShareholderPartialView", shareholderViewModel);
        }

        public IActionResult ShareholderDelete(int id)
        {
            _shareholderService.Delete(id);

            return Redirect("Shareholder");
        }

        [HttpPost]
        public IActionResult Shareholder(ShareholderViewModel shareholderViewModel)
        {
            if (ModelState.IsValid)
            {
                var shareholder = _shareholderService.GetById(shareholderViewModel.NewShareholder.Id);
                if (shareholder == null)
                {
                    shareholderViewModel.NewShareholder.CreatedDate = DateTime.Now;
                    shareholderViewModel.NewShareholder.CreatedUserName = User.Identity.Name;

                    _shareholderService.Add(shareholderViewModel.NewShareholder);
                }
                else
                {
                    shareholderViewModel.NewShareholder.Id = shareholder.Id;
                    shareholderViewModel.NewShareholder.Year = shareholder.Year;
                    shareholderViewModel.NewShareholder.CreatedDate = shareholder.CreatedDate;
                    shareholderViewModel.NewShareholder.CreatedUserName = shareholder.CreatedUserName;
                    shareholderViewModel.NewShareholder.ModifiedDate = DateTime.Now;
                    shareholderViewModel.NewShareholder.ModifedUserName = User.Identity.Name;

                    _shareholderService.Update(shareholderViewModel.NewShareholder);
                }
            }
            return Redirect("Shareholder");
        } 
        #endregion

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

        public IActionResult Schema()
        {
            return View();
        }
    }
}
