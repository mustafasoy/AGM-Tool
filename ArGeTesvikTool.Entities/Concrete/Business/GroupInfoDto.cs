using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class GroupInfoDto : AuditableEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string CountryText { get; set; }
        public DateTime FoundingDate { get; set; }
    }
}
