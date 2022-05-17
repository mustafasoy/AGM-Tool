using ArGeTesvikTool.Core.Entities;
using ArGeTesvikTool.WebUI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerson
{
    public class RdCenterPersonInfoDto : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string NameSurname { get; set; }
        public string CountryCode { get; set; }
        public string CountryText { get; set; }
        public EducationStatu EducationStatu { get; set; }
        public string GraduateUniversity { get; set; }
        public string UniversityDepartmant { get; set; }
        public string MasterUniversity { get; set; }
        public string MasterDepartmant { get; set; }
        public string DoctoralUniversity { get; set; }
        public string DoctoralDepartmant { get; set; }
        public PersonPosition PersonPosition { get; set; }
        public WorkType WorkType { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime StartDate { get; set; }


        public string UserId { get; set; }
        public AppIdentityUser User { get; set; }
    }

    public enum EducationStatu
    {
        [Display(Name = "Mesles Lisesi(Öğrenci)")]
        MeslekLiseOgrenci = 1,
        [Display(Name = "Mesles Lisesi")]
        MeslekLise = 2,
        [Display(Name = "Ön Lisans(Öğrenci)")]
        OnLisansOgrenci = 3,
        [Display(Name = "Ön Lisans")]
        OnLisans = 4,
        [Display(Name = "Lisans(Öğrenci)")]
        LisansOgrenci = 5,
        [Display(Name = "Lisans")]
        Lisans = 6,
        [Display(Name = "Yüksek Lisans(Öğrenci)")]
        YuksekLisansOgrenci = 7,
        [Display(Name = "Yüksek Lisans")]
        YuksekLisans = 8,
        [Display(Name = "Doktora(Öğrenci)")]
        DoktoraOgrenci = 9,
        [Display(Name = "Doktora")]
        Doktora = 10,
        [Display(Name = "Diğer")]
        Diger = 11,
    }

    public enum PersonPosition
    {
        [Display(Name = "Araştırmacı")]
        Arastirmaci = 1,
        [Display(Name = "Teknisyen")]
        Teknisyen = 2,
        [Display(Name = "Destek Personeli")]
        DestekPersonel = 3,
        [Display(Name = "Stajyer")]
        Stajyer = 4
    }

    public enum WorkType
    {
        [Display(Name = "Tam Zamanlı")]
        Tam = 1,
        [Display(Name = "Kısmi Zamanlı")]
        Kısmi = 2,
    }

}