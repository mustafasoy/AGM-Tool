using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.Report
{
    public class ActivityReportViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SelectListItem> PersonnelList { get; set; }
        public List<SelectListItem> ProjectList { get; set; }
        public List<SelectListItem> TimeAwayList { get; set; }
    }
}
