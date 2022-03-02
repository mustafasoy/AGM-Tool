using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerformance
{
    public class RdCenterPerformanceProjectMap
    {
        public RdCenterPerformanceProjectMap(EntityTypeBuilder<RdCenterPerformanceProjectDto> entity)
        {
            entity.ToTable("RdCenterPerformanceProjects");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.ProjectName)
                .HasColumnName("ProjectName")
                .HasMaxLength(256);

            entity.Property(x => x.CommercialProductName)
                .HasColumnName("CommercialProductName");

            entity.Property(x => x.IsImportProduct)
                .HasColumnName("IsImportProduct");

            entity.Property(x => x.Explanation)
                .HasColumnName("Explanation");

            entity.Property(x => x.Amount)
                .HasColumnName("Amount");

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