using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterTechIntellectualPropertyMap
    {
        public RdCenterTechIntellectualPropertyMap(EntityTypeBuilder<RdCenterTechIntellectualPropertyDto> entity)
        {
            entity.ToTable("RdCenterTechIntellectualProperties");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year").HasMaxLength(4);

            entity.Property(x => x.ProjectName)
                .HasColumnName("ProjectName")
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(x => x.ProperyType)
                .HasColumnName("ProperyType")
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(x => x.InventionType)
                .HasColumnName("InventionType")
                .IsRequired();

            entity.Property(x => x.International)
                .HasColumnName("International")
                .HasMaxLength(20);

            entity.Property(x => x.DevelopmentPlace)
                .HasColumnName("DevelopmentPlace")
                .HasMaxLength(30);

            entity.Property(x => x.Statu)
                .HasColumnName("Statu")
                .HasMaxLength(20);

            entity.Property(x => x.ApplicationDate)
                .HasColumnName("ApplicationDate")
                .HasColumnType("date");

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