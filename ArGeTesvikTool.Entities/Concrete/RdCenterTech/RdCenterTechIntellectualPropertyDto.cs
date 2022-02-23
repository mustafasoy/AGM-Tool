using ArGeTesvikTool.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechIntellectualPropertyDto : AuditableEntity
    {
        public string ProjectName { get; set; }
        public ProperyType ProperyType { get; set; }
        public string InventionType { get; set; }
        public International International { get; set; }
        public DevelopmentPlace DevelopmentPlace { get; set; }
        public Statu Statu { get; set; }
        public DateTime ApplicationDate { get; set; }
    }

    public enum ProperyType
    {
        Patent,
        Tasarım,
        Marka,
        [Display(Name = "Yayın, Makale, Bildiri")]
        YayınMakaleBildiri,
        [Display(Name = "Faydalı Model")]
        FaydalıModel,
        [Display(Name = "Endüstriyel Tasarım")]
        EndüstriyelTasarım,
        Yazılım,
        Triadik
    }

    public enum International
    {
        Ulusal,
        Uluslararası,
    }

    public enum DevelopmentPlace
    {
        [Display(Name = "Ar-Ge/Tasarım merkezi bünyesinde")]
        ArGeTasarım,
        [Display(Name = "İşletme bünyesinde")]
        Isletme
    }

    public enum Statu
    {
        Başvuru,
        Tescil,
    }
}
