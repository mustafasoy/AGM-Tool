using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterFinancialInfoDto: AuditableEntity
    {
        public decimal NetSales { get; set; }
        public decimal TotalAsset { get; set; }
        public decimal SortTermLoan { get; set; }
        public decimal LongTermLoan { get; set; }
        public decimal DomesticSales { get; set; }
        public decimal ExportSales { get; set; }
        public decimal GrossSales { get; set; }
        public decimal RDExpenditure { get; set; }
        public decimal AcquisitionTurnover { get; set; }
    }
}
