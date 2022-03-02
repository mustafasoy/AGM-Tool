using ArGeTesvikTool.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerson
{
    public class RdCenterPersonInfoDto : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string NameSurname { get; set; }
        public string Nationality { get; set; }
        public string EducationStatu { get; set; }
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
}