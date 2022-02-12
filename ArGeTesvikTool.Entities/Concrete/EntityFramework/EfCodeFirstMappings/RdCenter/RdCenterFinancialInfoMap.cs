using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter
{
    public class RdCenterFinancialInfoMap
    {
        public RdCenterFinancialInfoMap(EntityTypeBuilder<RdCenterFinancialInfoDto> entity)
        {
            entity.ToTable("RdCenterFinancialInfos");

            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.NetSales)
                .HasColumnName("NetSales");

            entity.Property(x => x.TotalAsset)
                .HasColumnName("TotalAsset");

            entity.Property(x => x.SortTermLoan)
                .HasColumnName("SortTermLoan");

            entity.Property(x => x.LongTermLoan)
                .HasColumnName("LongTermLoan");

            entity.Property(x => x.DomesticSales)
                .HasColumnName("DomesticSales");

            entity.Property(x => x.ExportSales)
                .HasColumnName("ExportSales");

            entity.Property(x => x.GrossSales)
                .HasColumnName("GrossSales");

            entity.Property(x => x.RDExpenditure)
                .HasColumnName("RDExpenditure");

            entity.Property(x => x.AcquisitionTurnover)
                .HasColumnName("AcquisitionTurnover");

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