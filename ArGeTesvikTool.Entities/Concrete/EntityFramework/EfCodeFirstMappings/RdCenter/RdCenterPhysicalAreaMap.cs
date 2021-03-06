using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter
{
    public class RdCenterPhysicalAreaMap
    {
        public RdCenterPhysicalAreaMap(EntityTypeBuilder<RdCenterPhysicalAreaDto> entity)
        {
            entity.ToTable("RdCenterPhysicalAreas");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.FileName)
                .HasColumnName("FileName")
                .HasMaxLength(256);

            entity.Property(x => x.Content)
                .HasColumnName("Content");

            entity.Property(x => x.ContentType)
                .HasColumnName("FileExtension")
                .HasMaxLength(256);

            entity.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("date");

            entity.Property(x => x.CreatedUserName)
                .HasColumnName("CreatedUserName")
                .HasMaxLength(256);
        }
    }
}
