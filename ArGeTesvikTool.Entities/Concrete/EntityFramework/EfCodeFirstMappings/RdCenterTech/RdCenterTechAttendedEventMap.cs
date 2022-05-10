using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
                .HasMaxLength(20)
                .HasConversion(x => x.ToString(), x => (ConferenceType)Enum.Parse(typeof(ConferenceType), x));
            
            entity.Property(x => x.AttendedEvent)
                .HasColumnName("AttendedEvent")
                .HasMaxLength(256);
            
            entity.Property(x => x.Location)
                .HasColumnName("Location")
                .HasMaxLength(10)
                .HasConversion(x => x.ToString(), x => (ConferenceLocation)Enum.Parse(typeof(ConferenceLocation), x));

            entity.Property(x => x.AttendDate)
                .HasColumnName("AttendDate")
                .HasMaxLength(30);
            
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
