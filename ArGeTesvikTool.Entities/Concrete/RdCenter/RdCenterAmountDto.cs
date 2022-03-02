using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterAmountDto : AuditableEntity
    {
        public decimal TaxExemption { get; set; }
        public decimal WithholdingIncentive { get; set; }
        public decimal PremiumSupport { get; set; }
        public decimal StampTaxException { get; set; }
        public decimal CustomTaxException { get; set; }
        public decimal IncentiveAmount { get; set; }
        public decimal TotalExpenditure { get; set; }
        public decimal AnnualTotal { get; set; }
        public decimal RatioTurnover { get; set; }
    }
}
