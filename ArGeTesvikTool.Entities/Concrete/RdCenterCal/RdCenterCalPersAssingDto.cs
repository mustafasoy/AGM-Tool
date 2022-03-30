using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalPersAssingDto : AuditableEntity
    {
        public string Email { get; set; }
        public string ProjectCode { get; set; }
    }
}
