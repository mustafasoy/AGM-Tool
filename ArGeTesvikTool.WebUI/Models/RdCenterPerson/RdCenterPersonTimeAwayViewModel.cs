using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterPerson
{
    public class RdCenterPersonTimeAwayViewModel
    {
        public RdCenterPersonTimeAwayDto NewTimeInfo { get; set; }
        public List<RdCenterPersonTimeAwayDto> TimeAwayList { get; set; }
    }
}
