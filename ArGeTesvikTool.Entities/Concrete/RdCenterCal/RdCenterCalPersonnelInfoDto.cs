using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalPersonnelInfoDto : AuditableEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
    }
}
