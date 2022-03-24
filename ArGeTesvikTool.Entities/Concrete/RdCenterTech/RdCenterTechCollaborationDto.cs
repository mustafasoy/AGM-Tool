using ArGeTesvikTool.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechCollaborationDto : AuditableEntity
    {
        public Collaboration Collaboration { get; set; }
        public string Partner { get; set; }
        public string CountryCode { get; set; }
        public string CountryText { get; set; }
        public string CollaborationType { get; set; }
    }

    public enum Collaboration
    {
        [Display(Name = "Üniversiteler")]
        Universiteler = 1,
        [Display(Name = "Ar-Ge/Tasarım Merkezleri")]
        Arge = 2,
        [Display(Name = "Diğer/Kurum,Kuruluş,Vakıf ve Fonlar")]
        Diger = 3,
    }
}
