using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterAmountDto : AuditableEntity
    {
        public string MaterialExpense { get; set; }
        public string DepreciationAmount { get; set; }
        public string PersonelExpense { get; set; }
        public string GeneralExpense { get; set; }
        public string ExternalBenefit { get; set; }
        public string TaxFee { get; set; }
        public string DesignExpense { get; set; }
        public string CashSupport { get; set; }
        public string TotalExpenditure { get; set; }
        public string TaxExemption { get; set; }
    }
}
