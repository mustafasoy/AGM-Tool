using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Business
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Intro()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }


    }
}
