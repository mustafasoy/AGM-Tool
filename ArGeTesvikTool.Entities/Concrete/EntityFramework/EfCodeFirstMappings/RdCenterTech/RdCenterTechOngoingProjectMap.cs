using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterTechOngoingProjectMap
    {
        public RdCenterTechOngoingProjectMap(EntityTypeBuilder<RdCenterTechOngoingProjectDto> entity)
        {
            entity.ToTable("RdCenterTechOngoingProjects");
            entity.HasIndex(x => x.Year)
                .IsUnique();

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
