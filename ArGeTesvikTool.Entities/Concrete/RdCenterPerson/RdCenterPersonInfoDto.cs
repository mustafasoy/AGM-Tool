using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerson
{
    public class RdCenterPersonInfoDto : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string NameSurname { get; set; }
        public string Nationality { get; set; }
        public string GraduateUniversity { get; set; }
        public string PersonPosition { get; set; }
        public int RegistrationNo { get; set; }
        public DateTime StartDate { get; set; }
    }
}