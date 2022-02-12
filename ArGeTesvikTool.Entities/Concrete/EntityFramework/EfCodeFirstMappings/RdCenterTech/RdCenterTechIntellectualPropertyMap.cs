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

            entity.Property(x => x.CompanyUnit)
                .HasColumnName("CompanyUnit")
                .HasMaxLength(256);

            entity.Property(x => x.PostDoctoral)
                .HasColumnName("PostDoctoral");

            entity.Property(x => x.Doctoral)
                .HasColumnName("Doctoral");

            entity.Property(x => x.MasterDegree)
                .HasColumnName("MasterDegree");

            entity.Property(x => x.BachelorDegree)
                .HasColumnName("BachelorDegree");

            entity.Property(x => x.AssociateDegree)
                .HasColumnName("AssociateDegree");

            entity.Property(x => x.HighSchool)
                .HasColumnName("HighSchool");

            entity.Property(x => x.Total)
                .HasColumnName("Total");

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