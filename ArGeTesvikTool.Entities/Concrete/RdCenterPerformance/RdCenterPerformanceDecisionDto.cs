using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerformance
{
    public class RdCenterPerformanceDecisionDto : AuditableEntity
    {
        public string ActivityYearText { get; set; }
        public string DecisionMeetText { get; set; }
    }
}
