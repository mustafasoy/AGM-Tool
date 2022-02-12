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

        public RdCenterController(IRdCenterContactService contactService, IRdCenterInfoService infoService, IRdCenterSchemaService schemaService, IRdCenterAreaInfoService areaInfoService)
        {
            _contactService = contactService;
            _infoService = infoService;
            _schemaService = schemaService;
            _areaInfoService = areaInfoService;
        }

        public IActionResult Contact(int year)
        {
            var contact = _contactService.GetByYear(year);

            RdCenterContactViewModel contactViewModel = new()
            {
                RdCenterContact = contact
            };

            return View(contactViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(RdCenterContactViewModel contactViewModel)
        {
            var validate = ValidatorTool.Validate(new RdCenterContactValidator(), contactViewModel.RdCenterContact);
            if (validate.IsValid)
            {
                //get data exist or not.
                var contact = _contactService.GetByYear(contactViewModel.RdCenterContact.Year);
                if (contact == null)
                {
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

        public IActionResult Info(int year)
        {
            var info = _infoService.GetByYear(year);

            if (info != null)
                ViewBag.City = info.City;

            RdCenterInfoViewModel infoViewModel = new()
            {
                RdCenterInfo = info
            };

            return View(infoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Info(RdCenterInfoViewModel infoViewModel)
        {
            var validate = ValidatorTool.Validate(new RdCenterInfoValidator(), infoViewModel.RdCenterInfo);
            if (validate.IsValid)
            {
                var info = _infoService.GetByYear(infoViewModel.RdCenterInfo.Year);
                if (info == null)
                {
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

        #region Schema
        public IActionResult Schema(int year)
        {
            var schemaList = _schemaService.GetAllByYear(year);

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
        [ValidateAntiForgeryToken]
        public IActionResult Schema(RdCenterSchemaViewModel schemaViewModel, List<IFormFile> FormFile)
        {
            RdCenterSchemaDto centerSchema = new();
            foreach (var item in FormFile)
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

            centerSchema.CreatedDate = DateTime.Now;
            centerSchema.CreatedUserName = User.Identity.Name;

            _schemaService.Add(centerSchema);

            AddSuccessMessage("ArGe merkezi organizasyon şeması eklendi.");

            return RedirectToAction("Schema");
        }
        #endregion

        #region AreaInfo
        public IActionResult AreaInfo(int year)
        {
            var areaInfoList = _areaInfoService.GetAllByYear(year);

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
        [ValidateAntiForgeryToken]
        public IActionResult AreaInfo(RdCenterAreaInfoViewModel areaInfoViewModel, List<IFormFile> FormFile)
        {
            RdCenterAreaInfoDto areaInfo = new();
            foreach (var item in FormFile)
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

            areaInfo.CreatedDate = DateTime.Now;
            areaInfo.CreatedUserName = User.Identity.Name;

            _areaInfoService.Add(areaInfo);

            AddSuccessMessage("ArGe merkezi fiziki alan bilgisi eklendi.");

            return RedirectToAction("AreaInfo");
        }
        #endregion
    }
}
