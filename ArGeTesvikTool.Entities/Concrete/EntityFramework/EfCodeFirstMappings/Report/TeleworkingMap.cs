using ArGeTesvikTool.Entities.Concrete.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Report
{
    public class TeleworkingMap
    {
        public TeleworkingMap(EntityTypeBuilder<TeleworkingDto> entity)
        {
            entity.ToTable("TeleworkingReports");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Month)
                .HasColumnName("Month")
                .HasMaxLength(2);

            entity.Property(x => x.PersonnelFullName)
                .HasColumnName("PersonnelFullName")
                .HasMaxLength(512);

            entity.Property(x => x.ProjectTimeSpend)
                .HasColumnName("ProjectTimeSpend")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.OutsideTimeSpend)
                .HasColumnName("OutsideTimeSpend")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.TeleworkingTimeSpend)
                .HasColumnName("TeleworkingTimeSpend")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.EditedTeleworkingTimeSpend)
                .HasColumnName("EditedTeleworkingTimeSpend")
                .HasColumnType("decimal(6,2)");
        }
    }
}
