using ArGeTesvikTool.Business.Abstract.Home;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models.Home;
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

            fiscalYear = fiscalYear.OrderByDescending(x => x.Year).ToList();

            FiscalYearViewModel fiscalYearViewModel = new()
            {
                YearList = fiscalYear
            };

            return View(fiscalYearViewModel);
        }
    }
}
