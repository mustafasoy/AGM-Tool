using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalTimeAwayDto: AuditableEntity
    {
        public string TimeAwayCode { get; set; }
        public string TimeAwayName { get; set; }
    }
}
