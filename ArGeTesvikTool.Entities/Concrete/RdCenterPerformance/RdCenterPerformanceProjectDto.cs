using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerformance
{
    public class RdCenterPerformanceProjectDto : AuditableEntity
    {
        public string ProjectName { get; set; }
        public string CommercialProductName { get; set; }
        public bool IsImportProduct { get; set; }
        public string Explanation { get; set; }
        public decimal Amount { get; set; }
    }
}
