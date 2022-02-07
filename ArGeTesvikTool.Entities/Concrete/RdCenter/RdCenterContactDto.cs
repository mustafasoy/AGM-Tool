using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterContactDto : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
