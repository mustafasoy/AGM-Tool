using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechMentorInfoDto : AuditableEntity
    {
        public string MentorFirmName { get; set; }
        public string MentorSupport { get; set; }
        public string MentorOutput { get; set; }
    }
}
