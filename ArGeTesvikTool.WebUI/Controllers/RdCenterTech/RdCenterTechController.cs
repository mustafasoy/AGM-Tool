using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterTech
{
    public class RdCenterTechController : Controller
    {
        public IActionResult CompletedProject()
        {
            return View();
        }

        public IActionResult OngoingProject()
        {
            return View();
        }

        public IActionResult Collaboration()
        {
            return View();
        }
        public IActionResult AcademicLibrary()
        {
            return View();
        }

        public IActionResult AttendedEvent()
        {
            return View();
        }

        public IActionResult Property()
        {
            return View();
        }

        public IActionResult Software()
        {
            return View();
        }
    }
}
