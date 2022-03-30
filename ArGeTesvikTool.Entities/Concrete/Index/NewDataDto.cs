using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Index
{
    public class NewDataDto: AuditableEntity
    {
        public int InternationalProjectNumber { get; set; }
        public int NationalProjectNumber { get; set; }
        public string PeriodicExpenditure { get; set; }
        public string PublicPeriodicExpenditure { get; set; }
        public string ProjectPeriodicExpenditure { get; set; }
        public string DomesticSalesRevenue { get; set; }
        public string OverseasSalesRevenue { get; set; }
        public bool IsIso14001 { get; set; }
        public bool IsIso9001 { get; set; }
    }
}
