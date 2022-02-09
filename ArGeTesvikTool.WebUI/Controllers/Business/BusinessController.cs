﻿using ArGeTesvikTool.Business.Abstract.Business;
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
        private readonly IPersonnelDistributionService _personnelService;

        public BusinessController(IBusinessContactService contactService, IBusinessInfoService infoService, IBusinessIntroService introService, IGroupInfoService groupInfoService, IShareholderService shareholderService, IPersonnelDistributionService personnelService)
        {
            _contactService = contactService;
            _infoService = infoService;
            _introService = introService;
            _groupInfoService = groupInfoService;
            _shareholderService = shareholderService;
            _personnelService = personnelService;
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

                    AddSuccessMessage("İşletme yetkili bilgisi eklendi.");
                    return RedirectToAction("Index", "Home");
                }

                contactViewModel.BusinessContact.Id = contact.Id;
                contactViewModel.BusinessContact.Year = contact.Year;
                contactViewModel.BusinessContact.CreatedDate = contact.CreatedDate;
                contactViewModel.BusinessContact.CreatedUserName = contact.CreatedUserName;
                contactViewModel.BusinessContact.ModifiedDate = DateTime.Now;
                contactViewModel.BusinessContact.ModifedUserName = User.Identity.Name;

                _contactService.Update(contactViewModel.BusinessContact);

                AddSuccessMessage("İşletme yetkili bilgisi güncellendi.");
                return RedirectToAction("Index", "Home");
            }

            AddValidatorError(validate);

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
            var validate = ValidatorTool.Validate(new BusinessInfoValidator(), infoViewModel.BusinessInfo);
            if (validate.IsValid)
            {
                var info = _infoService.GetByYear(infoViewModel.BusinessInfo.Year);
                if (info == null)
                {
                    infoViewModel.BusinessInfo.CreatedDate = DateTime.Now;
                    infoViewModel.BusinessInfo.CreatedUserName = User.Identity.Name;

                    _infoService.Add(infoViewModel.BusinessInfo);

                    AddSuccessMessage("İşletme bilgisi eklendi.");
                    return RedirectToAction("Index", "Home");
                }

                infoViewModel.BusinessInfo.Id = info.Id;
                infoViewModel.BusinessInfo.Year = info.Year;
                infoViewModel.BusinessInfo.CreatedDate = info.CreatedDate;
                infoViewModel.BusinessInfo.CreatedUserName = info.CreatedUserName;
                infoViewModel.BusinessInfo.ModifiedDate = DateTime.Now;
                infoViewModel.BusinessInfo.ModifedUserName = User.Identity.Name;

                _infoService.Update(infoViewModel.BusinessInfo);

                AddSuccessMessage("İşletme bilgisi güncellendi.");
                return RedirectToAction("Index", "Home");
            }

            AddValidatorError(validate);

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
            var intro = _introService.GetByYear(introViewModel.BusinessIntro.Year);
            if (intro == null)
            {
                introViewModel.BusinessIntro.CreatedDate = DateTime.Now;
                introViewModel.BusinessIntro.CreatedUserName = User.Identity.Name;
                _introService.Add(introViewModel.BusinessIntro);

                AddSuccessMessage("İşletme tanıtıcı bilgisi eklendi.");

                return RedirectToAction("Index", "Home");
            }

            introViewModel.BusinessIntro.Id = intro.Id;
            introViewModel.BusinessIntro.Year = intro.Year;
            introViewModel.BusinessIntro.CreatedDate = intro.CreatedDate;
            introViewModel.BusinessIntro.CreatedUserName = intro.CreatedUserName;
            introViewModel.BusinessIntro.ModifiedDate = DateTime.Now;
            introViewModel.BusinessIntro.ModifedUserName = User.Identity.Name;

            _introService.Update(introViewModel.BusinessIntro);

            AddSuccessMessage("İşletme tanıtıcı bilgisi güncellendi.");

            return RedirectToAction("Index", "Home");
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
            var validate = ValidatorTool.Validate(new BusinessGroupInfoValidator(), groupInfoViewModel.GroupInfo);
            if (validate.IsValid)
            {
                var groupInfo = _groupInfoService.GetByYear(groupInfoViewModel.GroupInfo.Year);
                if (groupInfo == null)
                {
                    groupInfoViewModel.GroupInfo.CreatedDate = DateTime.Now;
                    groupInfoViewModel.GroupInfo.CreatedUserName = User.Identity.Name;

                    _groupInfoService.Add(groupInfoViewModel.GroupInfo);

                    AddSuccessMessage("Yeni grup bilgisi eklendi.");
                    return RedirectToAction("Index", "Home");
                }

                groupInfoViewModel.GroupInfo.Id = groupInfo.Id;
                groupInfoViewModel.GroupInfo.Year = groupInfo.Year;
                groupInfoViewModel.GroupInfo.CreatedDate = groupInfo.CreatedDate;
                groupInfoViewModel.GroupInfo.CreatedUserName = groupInfo.CreatedUserName;
                groupInfoViewModel.GroupInfo.ModifiedDate = DateTime.Now;
                groupInfoViewModel.GroupInfo.ModifedUserName = User.Identity.Name;

                _groupInfoService.Update(groupInfoViewModel.GroupInfo);

                AddSuccessMessage("Grup bilgisi güncellendi.");
                return RedirectToAction("Index", "Home");

            }

            AddValidatorError(validate);

            return View(groupInfoViewModel);
        }

        #region Shareholder CRUD
        public IActionResult Shareholder()
        {
            List<ShareholdersDto> shareholderList = _shareholderService.GetAll();

            ShareholderViewModel shareholderViewModel = new()
            {
                ShareholderList = shareholderList
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

            return PartialView("PartialView/ShareholderPartialView", shareholderViewModel);
        }

        public IActionResult ShareholderDelete(int id)
        {
            _shareholderService.Delete(id);

            AddSuccessMessage("Ortaklık kaydı silindi.");

            return RedirectToAction("Shareholder");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Shareholder(ShareholderViewModel shareholderViewModel)
        {
            var shareholder = _shareholderService.GetById(shareholderViewModel.NewShareholder.Id);
            if (shareholder == null)
            {
                shareholderViewModel.NewShareholder.CreatedDate = DateTime.Now;
                shareholderViewModel.NewShareholder.CreatedUserName = User.Identity.Name;

                _shareholderService.Add(shareholderViewModel.NewShareholder);

                AddSuccessMessage("Yeni ortaklık kaydı eklendi.");
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

                AddSuccessMessage("Ortaklık kaydı güncellendi.");
            }

            return Redirect("Shareholder");
        }
        #endregion

        #region Personnel Distribution CRUD
        public IActionResult PersonnelDistribution()
        {
            List<PersonnelDistributionDto> personnelDistribution = _personnelService.GetAll();

            PersonnelDistributionViewModel personnelDistributionViewModel = new()
            {
                PersonnelDistributionList = personnelDistribution
            };

            return View(personnelDistributionViewModel);
        }

        public IActionResult PersonnelCreate()
        {
            PersonnelDistributionDto personnel = new();

            PersonnelDistributionViewModel personnelDistributionView = new()
            {
                NewPersonnel = personnel
            };

            return PartialView("PartialView/PersonnelPartialView", personnelDistributionView);
        }

        public IActionResult PersonnelUpdate(int id)
        {
            var personnel = _personnelService.GetById(id);

            PersonnelDistributionViewModel personnelDistributionView = new()
            {
                NewPersonnel = personnel
            };

            return PartialView("PartialView/PersonnelPartialView", personnelDistributionView);
        }

        public IActionResult PersonnelDelete(int id)
        {
            _personnelService.Delete(id);

            AddSuccessMessage("Personel kaydı silindi.");

            return Redirect("PersonnelDistribution");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonnelDistribution(PersonnelDistributionViewModel distributionViewModel)
        {
            var shareholder = _personnelService.GetById(distributionViewModel.NewPersonnel.Id);
            if (shareholder == null)
            {
                distributionViewModel.NewPersonnel.CreatedDate = DateTime.Now;
                distributionViewModel.NewPersonnel.CreatedUserName = User.Identity.Name;

                _personnelService.Add(distributionViewModel.NewPersonnel);

                AddSuccessMessage("Yeni personel kaydı eklendi.");
            }
            else
            {
                distributionViewModel.NewPersonnel.Id = shareholder.Id;
                distributionViewModel.NewPersonnel.Year = shareholder.Year;
                distributionViewModel.NewPersonnel.CreatedDate = shareholder.CreatedDate;
                distributionViewModel.NewPersonnel.CreatedUserName = shareholder.CreatedUserName;
                distributionViewModel.NewPersonnel.ModifiedDate = DateTime.Now;
                distributionViewModel.NewPersonnel.ModifedUserName = User.Identity.Name;

                _personnelService.Update(distributionViewModel.NewPersonnel);

                AddSuccessMessage("Personel kaydı güncellendi.");
            }

            return Redirect("PersonnelDistribution");
        }
        #endregion

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
