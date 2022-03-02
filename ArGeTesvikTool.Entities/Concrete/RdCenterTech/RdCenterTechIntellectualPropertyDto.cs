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
        Patent = 1,
        Tasarım = 2,
        Marka = 3,
        [Display(Name = "Yayın, Makale, Bildiri")]
        YayınMakaleBildiri = 4,
        [Display(Name = "Faydalı Model")]
        FaydaliModel = 5,
        [Display(Name = "Endüstriyel Tasarım")]
        EndüstriyelTasarim = 6,
        Yazılım = 7,
        Triadik = 8
    }

    public enum International
    {
        Ulusal = 1,
        Uluslararası = 2,
    }

    public enum DevelopmentPlace
    {
        [Display(Name = "Ar-Ge/Tasarım merkezi bünyesinde")]
        ArGeTasarım = 1,
        [Display(Name = "İşletme bünyesinde")]
        Isletme = 2
    }

    public enum Statu
    {
        Başvuru = 1,
        Tescil = 2,
    }
}
