using ArGeTesvikTool.Business.Abstract.Home;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Route("anasayfa")]
        public IActionResult Index()
        {
            List<FiscalYearDto> fiscalYear = _fiscalYearService.GetYearList();

            fiscalYear = fiscalYear.OrderByDescending(x => x.Year).ToList();

            FiscalYearViewModel fiscalYearViewModel = new()
            {
                YearList = fiscalYear
            };

            return View(fiscalYearViewModel);
        }

        [HttpPost]
        public void Index(int year)
        {
            HttpContext.Session.SetInt32("year", year);
        }
    }
}
