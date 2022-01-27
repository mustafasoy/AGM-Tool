using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.WebUI.Models.Business;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info(int year)
        {
            var businessInfo = _businessInfoService.GetByYear(year);

            BusinessInfoViewModel businessInfoView = new()
            {
                BusinessInfo = businessInfo
            };

            return View(businessInfoView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Info(BusinessInfoViewModel businessInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                _businessInfoService.Add(businessInfoViewModel.BusinessInfo);
                TempData["SuccessMessage"] = "Veriler eklendi...";
                return RedirectToAction("Index", "Home");
            }

            return View(businessInfoViewModel);
        }

        public IActionResult Intro(int year)
        {
            var businessIntro = _businessIntroService.GetByYear(year);

            BusinessIntroViewModel businessIntroView = new()
            {
                BusinessIntro = businessIntro
            };

            return View(businessIntroView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Intro(BusinessIntroViewModel businessIntroViewModel)
        {
            if (ModelState.IsValid)
            {
                _businessIntroService.Add(businessIntroViewModel.BusinessIntro);
                TempData["SuccessMessage"] = "Veriler eklendi...";
                return RedirectToAction("Index", "Home");
            }

            return View(businessIntroViewModel);
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
    }
}
