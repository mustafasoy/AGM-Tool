using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechAttendedEventViewModel
    {
        public RdCenterTechAttendedEventDto NewAttendedEvent { get; set; }
        public List<RdCenterTechAttendedEventDto> AttendedEventList { get; set; }
    }
}
