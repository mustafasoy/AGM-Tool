using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenter
{
    public class RdCenterController : BaseController
    {
        private readonly IRdCenterContactService _contactService;
        private readonly IRdCenterInfoService _infoService;
        private readonly IRdCenterSchemaService _schemaService;
        private readonly IRdCenterAreaInfoService _areaInfoService;
        private readonly IRdCenterPhysicalAreaService _physicalAreaService;
        private readonly IRdCenterAmountService _amountService;
        private readonly IRdCenterDiscountService _discountService;

        public RdCenterController(IRdCenterContactService contactService, IRdCenterInfoService infoService, IRdCenterSchemaService schemaService, IRdCenterAreaInfoService areaInfoService, IRdCenterPhysicalAreaService physicalAreaService, IRdCenterAmountService amountService, IRdCenterDiscountService discountService)
        {
            _contactService = contactService;
            _infoService = infoService;
            _schemaService = schemaService;
            _areaInfoService = areaInfoService;
            _physicalAreaService = physicalAreaService;
            _amountService = amountService;
            _discountService = discountService;
        }

        public IActionResult Contact()
        {
            var contact = _contactService.GetByYear(GetSelectedYear());

            RdCenterContactViewModel contactViewModel = new()
            {
                RdCenterContact = contact
            };

            return View(contactViewModel);
        }

        [HttpPost]
        public IActionResult Contact(RdCenterContactViewModel contactViewModel)
        {
            var validate = ValidatorTool.Validate(new RdCenterContactValidator(), contactViewModel.RdCenterContact);
            if (validate.IsValid)
            {
                //get data exist or not.
                var contact = _contactService.GetByYear(contactViewModel.RdCenterContact.Year);
                if (contact == null)
                {
                    contactViewModel.RdCenterContact.Year = GetSelectedYear();
                    contactViewModel.RdCenterContact.CreatedDate = DateTime.Now;
                    contactViewModel.RdCenterContact.CreatedUserName = User.Identity.Name;

                    _contactService.Add(contactViewModel.RdCenterContact);

                    AddSuccessMessage("ArGe merkezi yetkili bilgisi eklendi.");

                    return RedirectToAction("Index", "Home");
                }

                contactViewModel.RdCenterContact.Id = contact.Id;
                contactViewModel.RdCenterContact.Year = contact.Year;
                contactViewModel.RdCenterContact.CreatedDate = contact.CreatedDate;
                contactViewModel.RdCenterContact.CreatedUserName = contact.CreatedUserName;
                contactViewModel.RdCenterContact.ModifiedDate = DateTime.Now;
                contactViewModel.RdCenterContact.ModifedUserName = User.Identity.Name;

                _contactService.Update(contactViewModel.RdCenterContact);

                AddSuccessMessage("ArGe merkezi yetkili bilgisi güncellendi.");

                return RedirectToAction("Index", "Home");
            }

            AddValidatorError(validate);

            return View(contactViewModel);
        }

        public IActionResult Info()
        {
            var info = _infoService.GetByYear(GetSelectedYear());

            ViewBag.City = info != null
                ? info.CityCode
                : string.Empty;

            RdCenterInfoViewModel infoViewModel = new()
            {
                RdCenterInfo = info
            };

            return View(infoViewModel);
        }

        [HttpPost]
        public IActionResult Info(RdCenterInfoViewModel infoViewModel)
        {
            var validate = ValidatorTool.Validate(new RdCenterInfoValidator(), infoViewModel.RdCenterInfo);
            if (validate.IsValid)
            {
                var info = _infoService.GetByYear(infoViewModel.RdCenterInfo.Year);
                if (info == null)
                {
                    infoViewModel.RdCenterInfo.Year = GetSelectedYear();
                    infoViewModel.RdCenterInfo.CreatedDate = DateTime.Now;
                    infoViewModel.RdCenterInfo.CreatedUserName = User.Identity.Name;

                    _infoService.Add(infoViewModel.RdCenterInfo);

                    AddSuccessMessage("ArGe merkezi bilgisi eklendi.");
                    return RedirectToAction("Index", "Home");
                }

                infoViewModel.RdCenterInfo.Id = info.Id;
                infoViewModel.RdCenterInfo.Year = info.Year;
                infoViewModel.RdCenterInfo.CreatedDate = info.CreatedDate;
                infoViewModel.RdCenterInfo.CreatedUserName = info.CreatedUserName;
                infoViewModel.RdCenterInfo.ModifiedDate = DateTime.Now;
                infoViewModel.RdCenterInfo.ModifedUserName = User.Identity.Name;

                _infoService.Update(infoViewModel.RdCenterInfo);

                AddSuccessMessage("ArGe merkezi bilgisi güncellendi.");

                return RedirectToAction("Index", "Home");
            }

            AddValidatorError(validate);

            return View(infoViewModel);
        }

        #region Schema CRUD
        public IActionResult Schema()
        {
            var schemaList = _schemaService.GetAllByYear(GetSelectedYear());

            RdCenterSchemaViewModel schemaViewModel = new()
            {
                SchemaList = schemaList
            };

            return View(schemaViewModel);
        }

        public IActionResult SchemaDelete(int id)
        {
            _schemaService.Delete(id);

            AddSuccessMessage("ArGe merkezi organizasyon şeması silindi.");

            return RedirectToAction("Schema");
        }

        public IActionResult SchemaDownload(int id)
        {
            var schema = _schemaService.GetById(id);

            return DownloadFile(schema);
        }

        [HttpPost]
        public IActionResult Schema(RdCenterSchemaViewModel schemaViewModel, List<IFormFile> formFile)
        {
            RdCenterSchemaDto centerSchema = new();
            foreach (var item in formFile)
            {
                if (item.Length > 0)
                {
                    using var stream = new MemoryStream();
                    item.CopyToAsync(stream).Wait();
                    centerSchema.FileName = item.FileName;
                    centerSchema.Content = stream.ToArray();
                    centerSchema.ContentType = item.ContentType;
                }
            }

            var schemaList = _schemaService.GetAllByYear(2022);
            foreach (var item in schemaList)
            {
                if (item.FileName == centerSchema.FileName)
                {
                    ModelState.AddModelError("FormFile", "Dosya mevcut. Farklı dosya seçiniz");

                    schemaViewModel.SchemaList = schemaList;

                    return View(schemaViewModel);
                }
            }
            centerSchema.Year = GetSelectedYear();
            centerSchema.CreatedDate = DateTime.Now;
            centerSchema.CreatedUserName = User.Identity.Name;

            _schemaService.Add(centerSchema);

            AddSuccessMessage("ArGe merkezi organizasyon şeması eklendi.");

            return RedirectToAction("Schema");
        }
        #endregion

        #region AreaInfo CRUD
        public IActionResult AreaInfo()
        {
            var areaInfoList = _areaInfoService.GetAllByYear(GetSelectedYear());

            RdCenterAreaInfoViewModel areaInfoViewModel = new()
            {
                AreaInfoList = areaInfoList
            };

            return View(areaInfoViewModel);
        }

        public IActionResult AreaInfoDelete(int id)
        {
            _areaInfoService.Delete(id);

            AddSuccessMessage("ArGe merkezi fiziki alan bilgisi silindi.");

            return RedirectToAction("AreaInfo");
        }

        public IActionResult AreaInfoDownload(int id)
        {
            var areaInfo = _areaInfoService.GetById(id);

            return DownloadFile(areaInfo);
        }

        [HttpPost]
        public IActionResult AreaInfo(RdCenterAreaInfoViewModel areaInfoViewModel, List<IFormFile> formFile)
        {
            RdCenterAreaInfoDto areaInfo = new();
            foreach (var item in formFile)
            {
                if (item.Length > 0)
                {
                    using var stream = new MemoryStream();
                    item.CopyToAsync(stream).Wait();
                    areaInfo.FileName = item.FileName;
                    areaInfo.Content = stream.ToArray();
                    areaInfo.ContentType = item.ContentType;
                }
            }

            var areaInfoList = _areaInfoService.GetAllByYear(2022);
            foreach (var item in areaInfoList)
            {
                if (item.FileName == areaInfo.FileName)
                {
                    ModelState.AddModelError("FormFile", "Dosya mevcut. Farklı dosya seçiniz");

                    areaInfoViewModel.AreaInfoList = areaInfoList;

                    return View(areaInfoList);
                }
            }
            areaInfo.Year = GetSelectedYear();
            areaInfo.CreatedDate = DateTime.Now;
            areaInfo.CreatedUserName = User.Identity.Name;

            _areaInfoService.Add(areaInfo);

            AddSuccessMessage("ArGe merkezi fiziki alan bilgisi eklendi.");

            return RedirectToAction("AreaInfo");
        }
        #endregion

        #region PhysicalArea CRUD
        public IActionResult PhysicalArea()
        {
            var physicalAreaList = _physicalAreaService.GetAllByYear(GetSelectedYear());

            RdCenterPhysicalAreaViewModel physicalAreaViewModel = new()
            {
                PhysicalAreaList = physicalAreaList
            };

            return View(physicalAreaViewModel);
        }

        public IActionResult PhysicalAreaDelete(int id)
        {
            _physicalAreaService.Delete(id);

            AddSuccessMessage("Fiziki alan bilgisi silindi.");

            return RedirectToAction("PhysicalArea");
        }

        public IActionResult PhysicalAreaDownload(int id)
        {
            var physicalArea = _physicalAreaService.GetById(id);

            return DownloadFile(physicalArea);
        }

        [HttpPost]
        public IActionResult PhysicalArea(RdCenterPhysicalAreaViewModel physicalAreaViewModel, List<IFormFile> formFile)
        {
            RdCenterPhysicalAreaDto physicalArea = new();
            foreach (var item in formFile)
            {
                if (item.Length > 0)
                {
                    using var stream = new MemoryStream();
                    item.CopyToAsync(stream).Wait();
                    physicalArea.FileName = item.FileName;
                    physicalArea.Content = stream.ToArray();
                    physicalArea.ContentType = item.ContentType;
                }
            }

            var physicalAreaList = _physicalAreaService.GetAllByYear(2022);
            foreach (var item in physicalAreaList)
            {
                if (item.FileName == physicalArea.FileName)
                {
                    ModelState.AddModelError("FormFile", "Dosya mevcut. Farklı dosya seçiniz.");

                    physicalAreaViewModel.PhysicalAreaList = physicalAreaList;

                    return View(physicalAreaViewModel);
                }
            }
            physicalArea.Year = GetSelectedYear();
            physicalArea.CreatedDate = DateTime.Now;
            physicalArea.CreatedUserName = User.Identity.Name;

            _physicalAreaService.Add(physicalArea);

            AddSuccessMessage("Fiziki alan bilgisi eklendi.");

            return RedirectToAction("PhysicalArea");
        }
        #endregion

        #region Discount CRUD
        public IActionResult Discount()
        {
            List<RdCenterDiscountDto> discountList = _discountService.GetAllByYear(GetSelectedYear());

            RdCenterDiscountViewModel discountViewModel = new()
            {
                DiscountList = discountList
            };

            return View(discountViewModel);
        }

        public IActionResult DiscountCreate()
        {
            RdCenterDiscountDto discount = new();

            RdCenterDiscountViewModel discountViewModel = new()
            {
                NewDiscountInfo = discount
            };

            return PartialView("PartialView/DiscountPartialView", discountViewModel);
        }

        public IActionResult DiscountUpdate(int id)
        {
            var discount = _discountService.GetById(id);

            RdCenterDiscountViewModel discountViewModel = new()
            {
                NewDiscountInfo = discount
            };

            return PartialView("PartialView/DiscountPartialView", discountViewModel);
        }

        public IActionResult DiscountDelete(int id)
        {
            _discountService.Delete(id);

            AddSuccessMessage("5746 sayılı kanun kapsamında yararlanılan tutar bilgileri silindi.");

            return RedirectToAction("Amount");
        }

        [HttpPost]
        public IActionResult Discount(RdCenterDiscountViewModel discountViewModel)
        {
            var discount = _discountService.GetById(discountViewModel.NewDiscountInfo.Id);
            if (discount == null)
            {
                discountViewModel.NewDiscountInfo.Year = GetSelectedYear();
                discountViewModel.NewDiscountInfo.CreatedDate = DateTime.Now;
                discountViewModel.NewDiscountInfo.CreatedUserName = User.Identity.Name;

                _discountService.Add(discountViewModel.NewDiscountInfo);

                AddSuccessMessage("5746 sayılı kanun kapsamında yararlanılan tutar bilgileri eklendi.");
            }
            else
            {
                discountViewModel.NewDiscountInfo.Id = discount.Id;
                discountViewModel.NewDiscountInfo.Year = discount.Year;
                discountViewModel.NewDiscountInfo.CreatedDate = discount.CreatedDate;
                discountViewModel.NewDiscountInfo.CreatedUserName = discount.CreatedUserName;
                discountViewModel.NewDiscountInfo.ModifiedDate = DateTime.Now;
                discountViewModel.NewDiscountInfo.ModifedUserName = User.Identity.Name;

                _discountService.Update(discountViewModel.NewDiscountInfo);

                AddSuccessMessage("5746 sayılı kanun kapsamında yararlanılan tutar bilgileri güncellendi.");
            }

            return Redirect("Discount");
        }
        #endregion

        #region Amount CRUD
        public IActionResult Amount()
        {
            List<RdCenterAmountDto> amountList = _amountService.GetAllByYear(GetSelectedYear());

            RdCenterAmountViewModel amountViewModel = new()
            {
                AmountList = amountList
            };

            return View(amountViewModel);
        }

        public IActionResult AmountCreate()
        {
            RdCenterAmountDto amountInfo = new();

            RdCenterAmountViewModel amountViewModel = new()
            {
                NewAmountInfo = amountInfo
            };

            return PartialView("PartialView/AmountPartialView", amountViewModel);
        }

        public IActionResult AmountUpdate(int id)
        {
            var amount = _amountService.GetById(id);

            RdCenterAmountViewModel amountViewModel = new()
            {
                NewAmountInfo = amount
            };

            return PartialView("PartialView/AmountPartialView", amountViewModel);
        }

        public IActionResult AmountDelete(int id)
        {
            _amountService.Delete(id);

            AddSuccessMessage("Ar-Ge ve yenilik harcamalarının kapsamı bilgisi silindi.");

            return RedirectToAction("Amount");
        }

        [HttpPost]
        public IActionResult Amount(RdCenterAmountViewModel amountViewModel)
        {
            var amount = _amountService.GetById(amountViewModel.NewAmountInfo.Id);
            if (amount == null)
            {
                amountViewModel.NewAmountInfo.Year = GetSelectedYear();
                amountViewModel.NewAmountInfo.CreatedDate = DateTime.Now;
                amountViewModel.NewAmountInfo.CreatedUserName = User.Identity.Name;

                _amountService.Add(amountViewModel.NewAmountInfo);

                AddSuccessMessage("Ar-Ge ve yenilik harcamalarının kapsamı bilgisi eklendi.");
            }
            else
            {
                amountViewModel.NewAmountInfo.Id = amount.Id;
                amountViewModel.NewAmountInfo.Year = amount.Year;
                amountViewModel.NewAmountInfo.CreatedDate = amount.CreatedDate;
                amountViewModel.NewAmountInfo.CreatedUserName = amount.CreatedUserName;
                amountViewModel.NewAmountInfo.ModifiedDate = DateTime.Now;
                amountViewModel.NewAmountInfo.ModifedUserName = User.Identity.Name;

                _amountService.Update(amountViewModel.NewAmountInfo);

                AddSuccessMessage("Ar-Ge ve yenilik harcamalarının kapsamı bilgisi güncellendi.");
            }

            return Redirect("Amount");
        }
        #endregion
    }
}
