using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class BusinessContactDto : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
    }
}
