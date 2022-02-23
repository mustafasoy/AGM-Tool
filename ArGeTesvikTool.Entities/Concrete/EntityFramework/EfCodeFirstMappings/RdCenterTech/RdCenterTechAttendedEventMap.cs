using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterTechAttendedEventMap
    {
        public RdCenterTechAttendedEventMap(EntityTypeBuilder<RdCenterTechAttendedEventDto> entity)
        {
            entity.ToTable("RdCenterTechAttendedEvents");

            entity.Property(x => x.Id)
                .HasColumnName("Id");
            
            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Type)
                .HasColumnName("Text")
                .HasMaxLength(256);
            
            entity.Property(x => x.AttendedEvent)
                .HasColumnName("AttendedEvent")
                .HasMaxLength(256);
            
            entity.Property(x => x.Location)
                .HasColumnName("Location")
                .HasMaxLength(50);

            entity.Property(x => x.AttendDate)
                .HasColumnName("AttendDate")
                .HasColumnType("date");
            
            entity.Property(x => x.PersonNumber)
                .HasColumnName("PersonNumber");

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
