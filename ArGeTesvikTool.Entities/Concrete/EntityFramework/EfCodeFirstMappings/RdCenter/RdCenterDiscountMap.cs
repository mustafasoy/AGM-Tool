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

            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.MaterialExpense)
                .HasColumnName("MaterialExpense");

            entity.Property(x => x.DepreciationAmount)
                .HasColumnName("DepreciationAmount");

            entity.Property(x => x.PersonelExpense)
                .HasColumnName("PersonelExpense");

            entity.Property(x => x.GeneralExpense)
                .HasColumnName("GeneralExpense");

            entity.Property(x => x.ExternalBenefit)
                .HasColumnName("ExternalBenefit");

            entity.Property(x => x.TaxFee)
                .HasColumnName("TaxFee");

            entity.Property(x => x.DesignExpense)
                .HasColumnName("DesignExpense");

            entity.Property(x => x.CashSupport)
                .HasColumnName("CashSupport");

            entity.Property(x => x.TotalExpenditure)
                .HasColumnName("TotalExpenditure");

            entity.Property(x => x.TaxExemption)
                .HasColumnName("TaxExemption");

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