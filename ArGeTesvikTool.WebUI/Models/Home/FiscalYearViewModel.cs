using ArGeTesvikTool.Entities.Concrete;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.Home
{
    public class FiscalYearViewModel
    {
        public int Year { get; set; }
        public List<FiscalYearDto> YearList { get; set; }
    }
}
