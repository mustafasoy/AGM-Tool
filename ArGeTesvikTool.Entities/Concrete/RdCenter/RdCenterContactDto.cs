using ArGeTesvikTool.Entities.Abstract;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterContactDto : IEntity
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
    }
}
