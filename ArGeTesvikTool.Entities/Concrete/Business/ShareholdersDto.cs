using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class ShareholdersDto : AuditableEntity
    {
        public string CompanyName { get; set; }
        public string Origin { get; set; }
        public decimal Share { get; set; }
        public decimal ShareAmount { get; set; }
    }
}
