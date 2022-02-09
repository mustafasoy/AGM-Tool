using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation.RdCenter;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenter;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenter
{
    public class RdCenterController : BaseController
    {
        private readonly IRdCenterContactService _contactService;
        private readonly IRdCenterInfoService _infoService;
        public RdCenterController(IRdCenterContactService contactService, IRdCenterInfoService infoService)
        {
            _contactService = contactService;
            _infoService = infoService;
        }

        public IActionResult Contact(int id)
        {
            var contact = _contactService.GetByYear(id);

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

        public IActionResult Info(int id)
        {
            var info = _infoService.GetByYear(id);

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

        public IActionResult Schema()
        {
            return View();
        }
    }
}
