using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class BusinessFinancialInfoDto : AuditableEntity
    {
        public string NetSales { get; set; }
        public string TotalAsset { get; set; }
        public string SortTermLoan { get; set; }
        public string LongTermLoan { get; set; }
        public string DomesticSales { get; set; }
        public string ExportSales { get; set; }
        public string GrossSales { get; set; }
        public string RDExpenditure { get; set; }
        public string AcquisitionTurnover { get; set; }
    }
}
