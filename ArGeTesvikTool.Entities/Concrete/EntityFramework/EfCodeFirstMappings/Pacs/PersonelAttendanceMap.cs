using ArGeTesvikTool.Entities.Concrete.Pacs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Pacs
{
    public class PersonelAttendanceMap
    {
        public PersonelAttendanceMap(EntityTypeBuilder<PersonelAttendanceDto> entity)
        {
            entity.ToTable("PersonnelAttendances");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.UserId)
                .HasColumnName("UserId");

            entity.Property(x => x.PersonnelNumber)
                .HasColumnName("PersonnelNumber");

            entity.Property(x => x.EventTime)
                .HasColumnName("EventTime");

            entity.Property(x => x.Name)
                .HasColumnName("Name");

            entity.Property(x => x.Surname)
                .HasColumnName("Surname");

            entity.Property(x => x.TerminalId)
                .HasColumnName("TerminalId");

            entity.Property(x => x.TerminalName)
                .HasColumnName("TerminalName");
        }
    }
}
