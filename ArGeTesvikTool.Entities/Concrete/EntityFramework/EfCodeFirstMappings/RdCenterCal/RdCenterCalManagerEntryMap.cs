using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal
{
    public class RdCenterCalManagerEntryMap
    {
        public RdCenterCalManagerEntryMap(EntityTypeBuilder<RdCenterCalManagerEntryDto> entity)
        {
            entity.ToTable("RdCenterCalManagerEntries");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Mail)
                .HasColumnName("Mail")
                .HasMaxLength(256);

            entity.Property(x => x.ProjectCode)
                .HasColumnName("ProjectCode")
                .HasMaxLength(20);

            entity.Property(x => x.TimeAwayCode)
                .HasColumnName("TimeAwayCode")
                .HasMaxLength(20);

            entity.Property(x => x.Date)
                .HasColumnName("Date")
                .HasMaxLength(10);

            entity.Property(x => x.Time)
                .HasColumnName("Time")
                .HasMaxLength(10);

            entity.Property(x => x.Date_Time)
                .HasColumnName("DateTime")
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
