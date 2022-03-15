using ArGeTesvikTool.Business.Abstract.Home;
using ArGeTesvikTool.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.WebUI.Controllers.Home
{
    [Authorize]
    public class HomeController : Controller
    {
        IFiscalYearService _fiscalYearService;

        public HomeController(IFiscalYearService fiscalYearService)
        {
            _fiscalYearService = fiscalYearService;
        }

        public IActionResult Index()
        {
            List<FiscalYearDto> fiscalYear = _fiscalYearService.GetYearList();

            List<int> yearList = fiscalYear.OrderByDescending(x => x.Year)
                                           .Select(s => s.Year)
                                           .ToList();

            TempData["FiscalYear"] = yearList;
            //ViewBag.FiscalYear = yearList;

            return View();
        }

        [HttpPost]
        public IActionResult GetYear(string year)
        {
            return View();
        }
    }
}
