using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal
{
    public class RdCenterCalPersonnelEntryMap
    {
        public RdCenterCalPersonnelEntryMap(EntityTypeBuilder<RdCenterCalPersonnelEntryDto> entity)
        {
            entity.ToTable("RdCenterCalPersonnelEntries");

            entity.HasOne(s => s.User)
                .WithMany(g => g.PersonnelEntries)
                .HasForeignKey(s => s.UserId);

            entity.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(450);

            entity.Property(x => x.ProjectCode)
                .HasColumnName("ProjectCode")
                .HasMaxLength(20);

            entity.Property(x => x.ProjectName)
                .HasColumnName("ProjectName")
                .HasMaxLength(256);

            entity.Property(x => x.TimeAwayCode)
                .HasColumnName("TimeAwayCode")
                .HasMaxLength(20);

            entity.Property(x => x.TimeAwayName)
                .HasColumnName("TimeAwayName")
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
