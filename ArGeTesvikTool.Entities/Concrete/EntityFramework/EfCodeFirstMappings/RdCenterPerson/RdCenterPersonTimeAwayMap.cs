using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterPersonTimeAwayMap
    {
        public RdCenterPersonTimeAwayMap(EntityTypeBuilder<RdCenterPersonTimeAwayDto> entity)
        {
            entity.ToTable("RdCenterPersonTimeAways");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.IdentityNumber)
                .HasColumnName("IdentityNumber")
                .HasMaxLength(11);

            entity.Property(x => x.ProjectCode)
                .HasColumnName("ProjectCode")
                .HasMaxLength(256);

            entity.Property(x => x.ActivityType)
                .HasColumnName("ActivityType")
                .HasMaxLength(2);

            entity.Property(x => x.Month)
                .HasColumnName("Month")
                .HasMaxLength(2);

            entity.Property(x => x.MonthlyTimeAway)
                .HasColumnName("MonthlyTimeAway")
                .HasColumnType("decimal(4,2)");

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
