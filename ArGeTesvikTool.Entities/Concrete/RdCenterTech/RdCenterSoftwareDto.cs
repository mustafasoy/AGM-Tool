using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterSoftwareDto : AuditableEntity
    {
        public string SoftwareName { get; set; }
        public int CopyNumber { get; set; }
    }
}
