using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using System;

namespace ArGeTesvikTool.WebUI.Models.Authentication
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdentityNumber { get; set; }
        public string RegistrationNo { get; set; }
        public string CountryCode { get; set; }
        public string CountryText { get; set; }
        public string GraduateUniversity { get; set; }
        public string UniversityDepartmant { get; set; }
        public string MasterUniversity { get; set; }
        public string MasterDepartmant { get; set; }
        public string DoctoralUniversity { get; set; }
        public string DoctoralDepartmant { get; set; }
        public EducationStatu EducationStatu { get; set; }
        public PersonPosition PersonPosition { get; set; }
        public WorkType WorkType { get; set; }
        public DateTime StartDate { get; set; }
    }
}
