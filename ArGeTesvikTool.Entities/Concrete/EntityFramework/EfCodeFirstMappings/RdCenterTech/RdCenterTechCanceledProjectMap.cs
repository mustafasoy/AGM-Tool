using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterTechCanceledProjectMap
    {
        public RdCenterTechCanceledProjectMap(EntityTypeBuilder<RdCenterTechCanceledProjectDto> entity)
        {
            entity.ToTable("RdCenterTechCanceledProjects");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.ProjectCode)
                .HasColumnName("ProjectCode")
                .HasMaxLength(20);

            entity.Property(x => x.ProjectName)
                .HasColumnName("ProjectName")
                .HasMaxLength(256);

            entity.Property(x => x.EquityAmount)
                .HasColumnName("EquityAmount");

            entity.Property(x => x.SupportAmount)
                .HasColumnName("SupportAmount");

            entity.Property(x => x.ProgramName)
                .HasColumnName("ProgramName")
                .HasMaxLength(256);

            entity.Property(x => x.InternationalProgName)
                .HasColumnName("InternationalProgName")
                .HasMaxLength(256);

            entity.Property(x => x.TotalProjectBudget)
                .HasColumnName("TotalProjectBudget");
        }
    }
}