using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter
{
    public class RdCenterAmountMap
    {
        public RdCenterAmountMap(EntityTypeBuilder<RdCenterAmountDto> entity)
        {
            entity.ToTable("RdCenterAmounts");

            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.TaxExemption)
                .HasColumnName("TaxExemption");

            entity.Property(x => x.WithholdingIncentive)
                .HasColumnName("WithholdingIncentive");

            entity.Property(x => x.PremiumSupport)
                .HasColumnName("PremiumSupport");

            entity.Property(x => x.StampTaxException)
                .HasColumnName("StampTaxException");

            entity.Property(x => x.CustomTaxException)
                .HasColumnName("CustomTaxException");

            entity.Property(x => x.IncentiveAmount)
                .HasColumnName("IncentiveAmount");

            entity.Property(x => x.TotalExpenditure)
                .HasColumnName("TotalExpenditure");

            entity.Property(x => x.AnnualTotal)
                .HasColumnName("AnnualTotal");

            entity.Property(x => x.RatioTurnover)
                .HasColumnName("RatioTurnover");

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