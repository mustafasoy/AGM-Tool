using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterInfoDto : AuditableEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string RegistrationNo { get; set; }
        public int OfficeArea { get; set; }
        public int OtherArea { get; set; }
        public int TotalArea { get; set; }
    }
}
