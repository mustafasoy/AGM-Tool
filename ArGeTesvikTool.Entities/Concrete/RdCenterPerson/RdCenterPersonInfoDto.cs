using ArGeTesvikTool.Core.Entities;
using System;

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
        public string PersonPosition { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime StartDate { get; set; }
    }
}