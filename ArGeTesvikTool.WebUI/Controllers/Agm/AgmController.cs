using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Agm
{
    public class AgmController : Controller
    {
        public IActionResult Schema()
        {
            return View();
        }
    }
}
