using ArGeTesvikTool.Core.Entities;
using ArGeTesvikTool.Entities.Concrete.Business;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechAttendedEventDto : AuditableEntity
    {
        public Conference Type { get; set; }
        public string AttendedEvent { get; set; }
        public ConferenceLocation Location { get; set; }
        public DateTime AttendDate { get; set; }
        public int PersonNumber { get; set; }
    }
}
