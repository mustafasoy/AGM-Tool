using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterInfoDto : IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int PhoneNumber { get; set; }
        public string Mail { get; set; }
        public int RegistrationNo { get; set; }
        public int OfficeArea { get; set; }
        public int OtherArea { get; set; }
        public int TotalArea { get; set; }
    }
}
