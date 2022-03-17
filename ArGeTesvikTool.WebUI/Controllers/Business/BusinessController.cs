using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
        private readonly IBusinessSchemaService _schemaService;
        private readonly IStrategyService _strategyService;
        private readonly IBusinessFinancialInfoService _financialService;

        public BusinessController(IBusinessContactService contactService, IBusinessInfoService infoService, IBusinessIntroService introService, IGroupInfoService groupInfoService, IShareholderService shareholderService, IPersonnelDistributionService personnelService, IBusinessSchemaService schemaService, IStrategyService strategyService, IBusinessFinancialInfoService financialService)
        {
            _contactService = contactService;
            _infoService = infoService;
            _introService = introService;
            _groupInfoService = groupInfoService;
            _shareholderService = shareholderService;
            _personnelService = personnelService;
            _schemaService = schemaService;
            _strategyService = strategyService;
            _financialService = financialService;
        }

        public IActionResult Contact(int year)
        {
            var contact = _contactService.GetByYear(year);

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
                //verify identity number
                bool checkIdentity = VerifyIdentityNumber(contactViewModel.BusinessContact.IdentityNumber);
                if (!checkIdentity)
                {
                    ModelState.AddModelError("BusinessContact.IdentityNumber", "Kimlik numarasını kontrol ediniz.");
                    return View(contactViewModel);
                }

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

        public IActionResult Info(int year)
        {
            var info = _infoService.GetByYear(year);

            ViewBag.City = info != null
                ? info.CityCode
                : string.Empty;

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

        public IActionResult Intro(int year)
        {
            var intro = _introService.GetByYear(year);

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

        public IActionResult GroupInfo(int year)
        {
            var groupInfo = _groupInfoService.GetByYear(year);
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

        #region Financial CRUD
        public IActionResult FinancialInfo()
        {
            List<BusinessFinancialInfoDto> financialInfo = _financialService.GetAll();

            FinancialInfoViewModel financialInfoViewModel = new()
            {
                FinancialInfoList = financialInfo
            };

            return View(financialInfoViewModel);
        }

        public IActionResult FinancialCreate()
        {
            BusinessFinancialInfoDto financialInfo = new();

            FinancialInfoViewModel financialInfoViewModel = new()
            {
                NewFinancialInfo = financialInfo
            };

            return PartialView("PartialView/FinancialPartialView", financialInfoViewModel);
        }

        public IActionResult FinancialUpdate(int id)
        {
            var financialInfo = _financialService.GetById(id);

            FinancialInfoViewModel financialInfoViewModel = new()
            {
                NewFinancialInfo = financialInfo
            };

            return PartialView("PartialView/FinancialPartialView", financialInfoViewModel);
        }

        public IActionResult FinancialDelete(int id)
        {
            _financialService.Delete(id);

            AddSuccessMessage("Finansal bilgi kaydı silindi.");

            return Redirect("FinancialInfo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FinancialInfo(FinancialInfoViewModel financialInfoViewModel)
        {
            var financialInfo = _financialService.GetById(financialInfoViewModel.NewFinancialInfo.Id);
            if (financialInfo == null)
            {
                financialInfoViewModel.NewFinancialInfo.CreatedDate = DateTime.Now;
                financialInfoViewModel.NewFinancialInfo.CreatedUserName = User.Identity.Name;

                _financialService.Add(financialInfoViewModel.NewFinancialInfo);

                AddSuccessMessage("Yeni finansal bilgi kaydı eklendi.");
            }
            else
            {
                financialInfoViewModel.NewFinancialInfo.Id = financialInfo.Id;
                financialInfoViewModel.NewFinancialInfo.Year = financialInfo.Year;
                financialInfoViewModel.NewFinancialInfo.CreatedDate = financialInfo.CreatedDate;
                financialInfoViewModel.NewFinancialInfo.CreatedUserName = financialInfo.CreatedUserName;
                financialInfoViewModel.NewFinancialInfo.ModifiedDate = DateTime.Now;
                financialInfoViewModel.NewFinancialInfo.ModifedUserName = User.Identity.Name;

               _financialService.Update(financialInfoViewModel.NewFinancialInfo);

                AddSuccessMessage("Finansal bilgi kaydı güncellendi.");
            }

            return Redirect("FinancialInfo");
        }
        #endregion

        #region Schema CRUD
        public IActionResult Schema(int year)
        {
            var schemaList = _schemaService.GetAllByYear(year);

            BusinessSchemaViewModel schemaViewModel = new()
            {
                SchemaList = schemaList
            };

            return View(schemaViewModel);
        }

        public IActionResult SchemaDelete(int id)
        {
            _schemaService.Delete(id);

            AddSuccessMessage("İşletme organizasyon şeması silindi.");

            return RedirectToAction("Schema");
        }

        public IActionResult SchemaDownload(int id)
        {
            var schema = _schemaService.GetById(id);

            return DownloadFile(schema);

            //AddSuccessMessage("İşletme organizasyon şeması silindi.");

            //return RedirectToAction("Schema");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Schema(BusinessSchemaViewModel schemaViewModel, List<IFormFile> formFile)
        {
            if (ModelState.IsValid)
            {
                BusinessSchemaDto businessSchema = new();
                foreach (var item in formFile)
                {
                    if (item.Length > 0)
                    {
                        using var stream = new MemoryStream();
                        item.CopyToAsync(stream).Wait();
                        businessSchema.FileName = item.FileName;
                        businessSchema.Content = stream.ToArray();
                        businessSchema.ContentType = item.ContentType;
                    }
                }

                var schema = _schemaService.GetAllByYear(2022);
                foreach (var item in schema)
                {
                    if (item.FileName == businessSchema.FileName)
                    {
                        ModelState.AddModelError("FormFile", "Dosya mevcut. Farklı dosya seçiniz");

                        schemaViewModel.SchemaList = schema;

                        return View(schemaViewModel);
                    }
                }

                businessSchema.CreatedDate = DateTime.Now;
                businessSchema.CreatedUserName = User.Identity.Name;

                _schemaService.Add(businessSchema);

                AddSuccessMessage("İşletme organizasyon şeması eklendi.");

                return RedirectToAction("Schema");
            }

            return View(schemaViewModel);
        }
        #endregion

        public IActionResult Strategy(int year)
        {
            var strategy = _strategyService.GetByYear(year);


            StrategyViewModel strategyViewModel = new()
            {
                Strategy = strategy
            };

            return View(strategyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Strategy(StrategyViewModel strategyViewModel)
        {
            var strategy = _strategyService.GetByYear(strategyViewModel.Strategy.Year);
            if (strategy == null)
            {
                strategyViewModel.Strategy.CreatedDate = DateTime.Now;
                strategyViewModel.Strategy.CreatedUserName = User.Identity.Name;
                _strategyService.Add(strategyViewModel.Strategy);

                AddSuccessMessage("İşletme strateji bilgisi eklendi.");

                return RedirectToAction("Index", "Home");
            }

            strategyViewModel.Strategy.Id = strategy.Id;
            strategyViewModel.Strategy.Year = strategy.Year;
            strategyViewModel.Strategy.CreatedDate = strategy.CreatedDate;
            strategyViewModel.Strategy.CreatedUserName = strategy.CreatedUserName;
            strategyViewModel.Strategy.ModifiedDate = DateTime.Now;
            strategyViewModel.Strategy.ModifedUserName = User.Identity.Name;

            _strategyService.Update(strategyViewModel.Strategy);

            AddSuccessMessage("İşletme strateji bilgisi güncellendi.");

            return RedirectToAction("Index", "Home");
        }
    }
}
