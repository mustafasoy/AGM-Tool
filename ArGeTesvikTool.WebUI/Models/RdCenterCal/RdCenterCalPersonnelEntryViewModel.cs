using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalPersonnelEntryViewModel
    {
        public List<SelectListItem> ProjectList { get; set; }
        public List<SelectListItem> TimeAwayList { get; set; }
        public List<RdCenterCalPersonnelEntryDto> PersonnelEntryList { get; set; }
    }
}
