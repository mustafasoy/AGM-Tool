using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter
{
    public class RdCenterDiscountMap
    {
        public RdCenterDiscountMap(EntityTypeBuilder<RdCenterDiscountDto> entity)
        {
            entity.ToTable("RdCenterDiscounts");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.TaxExemption)
                .HasColumnName("TaxExemption")
                .HasMaxLength(20);

            entity.Property(x => x.WithholdingIncentive)
                .HasColumnName("WithholdingIncentive")
                .HasMaxLength(20);

            entity.Property(x => x.PremiumSupport)
                .HasColumnName("PremiumSupport")
                .HasMaxLength(20);

            entity.Property(x => x.StampTaxException)
                .HasColumnName("StampTaxException")
                .HasMaxLength(20);

            entity.Property(x => x.CustomTaxException)
                .HasColumnName("CustomTaxException")
                .HasMaxLength(20);

            entity.Property(x => x.IncentiveAmount)
                .HasColumnName("IncentiveAmount")
                .HasMaxLength(20);

            entity.Property(x => x.TotalExpenditure)
                .HasColumnName("TotalExpenditure")
                .HasMaxLength(20);

            entity.Property(x => x.AnnualTotal)
                .HasColumnName("AnnualTotal")
                .HasMaxLength(20);

            entity.Property(x => x.RatioTurnover)
                .HasColumnName("RatioTurnover")
                .HasMaxLength(20);

            entity.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("date");

            entity.Property(x => x.CreatedUserName)
                .HasColumnName("CreatedUserName")
                .HasMaxLength(256);

            entity.Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("date");

            entity.Property(x => x.ModifedUserName)
                .HasColumnName("ModifedUserName")
                .HasMaxLength(256);
        }
    }
}