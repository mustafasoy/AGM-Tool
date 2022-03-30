using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalTimeAwayViewModel
    {
        public RdCenterCalTimeAwayDto NewTimeAway { get; set; }
        public List<RdCenterCalTimeAwayDto> TimeAwayList { get; set; }
    }
}
