using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterTechCollaborationMap
    {
        public RdCenterTechCollaborationMap(EntityTypeBuilder<RdCenterTechCollaborationDto> entity)
        {
            entity.ToTable("RdCenterTechCollaborations");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Collaboration)
                .HasColumnName("Collaboration")
                .HasMaxLength(256);
            
            entity.Property(x => x.Partner)
                .HasColumnName("Partner")
                .HasMaxLength(256);
            
            entity.Property(x => x.CountryCode)
                .HasColumnName("CountryCode")
                .HasMaxLength(4);

            entity.Property(x => x.CountryText)
                .HasColumnName("CountryText")
                .HasMaxLength(50);

            entity.Property(x => x.CollaborationType)
                .HasColumnName("CollaborationType")
                .HasMaxLength(256);

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
