using ArGeTesvikTool.Entities.Concrete.Index;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Index
{
    public class NewDataMap
    {
        public NewDataMap(EntityTypeBuilder<NewDataDto> entity)
        {
            entity.ToTable("IndexNewDatas");

            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.InternationalProjectNumber)
                .HasColumnName("InternationalProjectNumber");

            entity.Property(x => x.NationalProjectNumber)
                .HasColumnName("NationalProjectNumber");

            entity.Property(x => x.PeriodicExpenditure)
                .HasColumnName("PeriodicExpenditure")
                .HasMaxLength(20);

            entity.Property(x => x.ProjectPeriodicExpenditure)
                .HasColumnName("ProjectPeriodicExpenditure")
                .HasMaxLength(20);

            entity.Property(x => x.PublicPeriodicExpenditure)
                .HasColumnName("PublicPeriodicExpenditure")
                .HasMaxLength(20);

            entity.Property(x => x.DomesticSalesRevenue)
                .HasColumnName("DomesticSalesRevenue")
                .HasMaxLength(20);

            entity.Property(x => x.OverseasSalesRevenue)
                .HasColumnName("OverseasSalesRevenue")
                .HasMaxLength(20);

            entity.Property(x => x.IsIso14001)
                .HasColumnName("Iso14001");

            entity.Property(x => x.IsIso9001)
                .HasColumnName("Iso9001");

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
