using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechCollaborationDto : AuditableEntity
    {
        public string Collaboration { get; set; }
        public string Partner { get; set; }
        public string Country { get; set; }
        public string CollaborationType { get; set; }
    }
}
