using ArGeTesvikTool.Business.Abstract.Business;
using Microsoft.AspNetCore.Mvc;

namespace ArGeTesvikTool.WebUI.Controllers.Business
{
    public class BusinessController : Controller
    {
        private IBusinessInfoService _businessInfoService;

        public BusinessController(IBusinessInfoService businessInfoService)
        {
            _businessInfoService = businessInfoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Intro()
        {
            return View();
        }
    }
}
