using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalPublicHolidayViewModel
    {
        public RdCenterCalPublicHolidayDto NewHoliday { get; set; }
        public List<RdCenterCalPublicHolidayDto> HolidayList { get; set; }

        public List<SelectListItem> YearList { get; set; }
    }
}
