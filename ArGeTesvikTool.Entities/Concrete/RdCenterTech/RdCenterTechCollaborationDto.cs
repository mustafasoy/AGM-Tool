using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechCollaborationDto : AuditableEntity
    {
        public string Collaboration { get; set; }
        public string Partner { get; set; }
        public string CountryCode { get; set; }
        public string CountryText { get; set; }
        public string CollaborationType { get; set; }
    }
}
