using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterAttendedEventDto : AuditableEntity
    {
        public string Type { get; set; }
        public string AttendedEvent { get; set; }
        public string Location { get; set; }
        public DateTime AttendDate { get; set; }
        public int PersonNumber { get; set; }
    }
}
