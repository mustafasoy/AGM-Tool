using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterDiscountDto : AuditableEntity
    {
        public decimal MaterialExpense { get; set; }
        public decimal DepreciationAmount { get; set; }
        public decimal PersonelExpense { get; set; }
        public decimal GeneralExpense { get; set; }
        public decimal ExternalBenefit { get; set; }
        public decimal TaxFee { get; set; }
        public decimal DesignExpense { get; set; }
        public decimal CashSupport { get; set; }
        public decimal TotalExpenditure { get; set; }
        public decimal TaxExemption { get; set; }
    }
}