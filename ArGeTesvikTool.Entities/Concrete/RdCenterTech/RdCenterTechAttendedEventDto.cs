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
        public string AttendDate { get; set; }
        public int PersonNumber { get; set; }
    }

    public enum ConferenceType
    {
        Konferans, Kongre, Sempozyum
    }

    public enum ConferenceLocation
    {
        [Display(Name ="Yurt içi")]
        Yurtiçi,
        [Display(Name = "Yurt dışı")]
        Yurtdışı
    }
}
