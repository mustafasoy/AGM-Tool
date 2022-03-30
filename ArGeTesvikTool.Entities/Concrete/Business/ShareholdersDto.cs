using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class ShareholdersDto : AuditableEntity
    {
        public string CompanyName { get; set; }
        public string CountryCode { get; set; }
        public string CountryText { get; set; }
        public decimal Share { get; set; }
        public string ShareAmount { get; set; }
    }
}
