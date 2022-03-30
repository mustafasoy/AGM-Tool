using ArGeTesvikTool.Core.Entities;
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
        public PersonPosition PersonPosition { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime StartDate { get; set; }
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

    public enum EducationStatu
    {
        [Display(Name = "Ön Lisans(Öğrenci)")]
        OnLisansOgrenci = 1,
        [Display(Name = "Ön Lisans")]
        OnLisans = 2,
        [Display(Name = "Lisans(Öğrenci)")]
        LisansOgrenci = 3,
        [Display(Name = "Lisans")]
        Lisans = 4,
        [Display(Name = "Yüksek Lisans(Öğrenci)")]
        YuksekLisansOgrenci = 5,
        [Display(Name = "Yüksek Lisans")]
        YuksekLisans = 6,
        [Display(Name = "Doktora(Öğrenci)")]
        DoktoraOgrenci = 7,
        [Display(Name = "Doktora")]
        Doktora = 8,
    }
}