using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterDiscountDto : AuditableEntity
    {
        public string TaxExemption { get; set; }
        public string WithholdingIncentive { get; set; }
        public string PremiumSupport { get; set; }
        public string StampTaxException { get; set; }
        public string CustomTaxException { get; set; }
        public string IncentiveAmount { get; set; }
        public string TotalExpenditure { get; set; }
        public string AnnualTotal { get; set; }
        public string RatioTurnover { get; set; }
    }
}