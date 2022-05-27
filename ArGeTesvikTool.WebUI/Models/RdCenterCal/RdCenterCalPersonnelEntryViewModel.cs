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
        public string ProjectTime { get; set; }
        public string ProjectMin { get; set; }
        public string TimeAwayTime { get; set; }
        public string TimeAwayMin { get; set; }
    }
}
