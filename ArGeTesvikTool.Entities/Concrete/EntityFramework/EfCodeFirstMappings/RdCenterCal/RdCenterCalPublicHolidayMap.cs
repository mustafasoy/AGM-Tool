using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal
{
    public class RdCenterCalPublicHolidayMap
    {
        public RdCenterCalPublicHolidayMap(EntityTypeBuilder<RdCenterCalPublicHolidayDto> entity)
        {
            entity.ToTable("RdCenterCalPublicHolidays");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Month)
                .HasColumnName("Month")
                .HasMaxLength(2);

            entity.Property(x => x.HolidayName)
                .HasColumnName("HolidayName")
                .HasMaxLength(100);

            entity.Property(x => x.IsHalfDay)
                .HasColumnName("IsHalfDay");

            entity.Property(x => x.StartDate)
                .HasColumnName("StartDate");

            entity.Property(x => x.EndDate)
                .HasColumnName("EndDate");

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
