using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechSoftwareDto : AuditableEntity
    {
        public string SoftwareName { get; set; }
        public int CopyNumber { get; set; }
    }
}
