using ArGeTesvikTool.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechAttendedEventDto : AuditableEntity
    {
        public ConferenceType Type { get; set; }
        public string AttendedEvent { get; set; }
        public ConferenceLocation Location { get; set; }
        public DateTime AttendDate { get; set; }
        public int PersonNumber { get; set; }
    }

    public enum ConferenceType
    {
        Konferans = 1,
        Kongre = 2,
        Sempozyum = 3
    }

    public enum ConferenceLocation
    {
        [Display(Name = "Yurt içi")]
        Yurtici = 1,
        [Display(Name = "Yurt dışı")]
        Yurtdisi = 2
    }
}
