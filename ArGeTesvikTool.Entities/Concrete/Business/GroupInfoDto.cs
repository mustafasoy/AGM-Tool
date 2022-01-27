using ArGeTesvikTool.Entities.Abstract;
using System;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class GroupInfoDto : IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Origin { get; set; }
        public DateTime FoundingDate { get; set; }
    }
}
