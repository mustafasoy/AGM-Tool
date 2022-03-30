using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal
{
    public class RdCenterCalPersAttendanceMap
    {
        public RdCenterCalPersAttendanceMap(EntityTypeBuilder<RdCenterCalPersAttendanceDto> entity)
        {
            entity.ToTable("RdCenterCalPersAttendances");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(16);

            entity.Property(x => x.PersonnelNumber)
                .HasColumnName("PersonnelNumber")
                .HasMaxLength(20);

            entity.Property(x => x.EventTime)
                .HasColumnName("EventTime");

            entity.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(75);

            entity.Property(x => x.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(75);

            entity.Property(x => x.TerminalId)
                .HasColumnName("TerminalId");

            entity.Property(x => x.TerminalName)
                .HasColumnName("TerminalName")
                .HasMaxLength(50);
        }
    }
}
