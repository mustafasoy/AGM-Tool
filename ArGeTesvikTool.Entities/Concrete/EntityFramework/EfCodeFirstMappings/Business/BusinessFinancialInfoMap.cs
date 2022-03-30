using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Business
{
    public class BusinessFinancialInfoMap
    {
        public BusinessFinancialInfoMap(EntityTypeBuilder<BusinessFinancialInfoDto> entity)
        {
            entity.ToTable("BusinessFinancialInfos");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.NetSales)
                .HasColumnName("NetSales")
                .HasMaxLength(20);

            entity.Property(x => x.TotalAsset)
                .HasColumnName("TotalAsset")
                .HasMaxLength(20);

            entity.Property(x => x.SortTermLoan)
                .HasColumnName("SortTermLoan")
                .HasMaxLength(20);

            entity.Property(x => x.LongTermLoan)
                .HasColumnName("LongTermLoan")
                .HasMaxLength(20);

            entity.Property(x => x.DomesticSales)
                .HasColumnName("DomesticSales")
                .HasMaxLength(20);

            entity.Property(x => x.ExportSales)
                .HasColumnName("ExportSales")
                .HasMaxLength(20);

            entity.Property(x => x.GrossSales)
                .HasColumnName("GrossSales")
                .HasMaxLength(20);

            entity.Property(x => x.RDExpenditure)
                .HasColumnName("RDExpenditure")
                .HasMaxLength(20);

            entity.Property(x => x.AcquisitionTurnover)
                .HasColumnName("AcquisitionTurnover")
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
