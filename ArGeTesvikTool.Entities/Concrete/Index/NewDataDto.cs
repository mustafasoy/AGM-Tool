using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Index
{
    public class NewDataDto: AuditableEntity
    {
        public int InternationalProjectNumber { get; set; }
        public int NationalProjectNumber { get; set; }
        public decimal PeriodicExpenditure { get; set; }
        public decimal PublicPeriodicExpenditure { get; set; }
        public decimal ProjectPeriodicExpenditure { get; set; }
        public decimal DomesticSalesRevenue { get; set; }
        public decimal OverseasSalesRevenue { get; set; }
        public bool IsIso14001 { get; set; }
        public bool IsIso9001 { get; set; }
    }
}
