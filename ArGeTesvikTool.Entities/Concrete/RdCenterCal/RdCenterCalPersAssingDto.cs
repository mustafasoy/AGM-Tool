using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalPersAssingDto : AuditableEntity
    {
        public string Mail { get; set; }
        public string ProjectCode { get; set; }
    }
}
