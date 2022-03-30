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

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.MaterialExpense)
                .HasColumnName("MaterialExpense")
                .HasMaxLength(20);

            entity.Property(x => x.DepreciationAmount)
                .HasColumnName("DepreciationAmount")
                .HasMaxLength(20);

            entity.Property(x => x.PersonelExpense)
                .HasColumnName("PersonelExpense")
                .HasMaxLength(20);

            entity.Property(x => x.GeneralExpense)
                .HasColumnName("GeneralExpense")
                .HasMaxLength(20);

            entity.Property(x => x.ExternalBenefit)
                .HasColumnName("ExternalBenefit")
                .HasMaxLength(20);

            entity.Property(x => x.TaxFee)
                .HasColumnName("TaxFee")
                .HasMaxLength(20);

            entity.Property(x => x.DesignExpense)
                .HasColumnName("DesignExpense")
                .HasMaxLength(20);

            entity.Property(x => x.CashSupport)
                .HasColumnName("CashSupport")
                .HasMaxLength(20);

            entity.Property(x => x.TotalExpenditure)
                .HasColumnName("TotalExpenditure")
                .HasMaxLength(20);

            entity.Property(x => x.TaxExemption)
                .HasColumnName("TaxExemption")
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