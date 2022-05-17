using ArGeTesvikTool.Entities.Concrete.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Report
{
    public class SocialSecurityMap
    {
        public SocialSecurityMap(EntityTypeBuilder<SocialSecurityDto> entity)
        {
            entity.ToTable("SocialSecurityReports");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Month)
                .HasColumnName("Month")
                .HasMaxLength(2);

            entity.Property(x => x.PersonnelFullName)
                .HasColumnName("PersonnelFullName")
                .HasMaxLength(512);

            entity.Property(x => x.RegistrationNo)
                .HasColumnName("RegistrationNo")
                .HasMaxLength(26);

            entity.Property(x => x.WorkType)
                .HasColumnName("WorkType")
                .HasMaxLength(20);

            entity.Property(x => x.WeekNumber)
                .HasColumnName("WeekNumber");

            entity.Property(x => x.PreMonthTransfer)
                .HasColumnName("PreMonthTransfer")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.IncentiveWorkingHour)
                .HasColumnName("IncentiveWorkingHour")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.PreMonthAnnuelLeaveHour)
                .HasColumnName("PreMonthAnnuelLeaveHour")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.AnnuelLeaveWorkingHour)
                .HasColumnName("AnnuelLeaveWorkingHour")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.WeekendWorkingHour)
                .HasColumnName("WeekendWorkingHour")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.PublicHolidayWorkingHour)
                .HasColumnName("PublicHolidayWorkingHour")
                .HasColumnType("decimal(6,2)");

            entity.Property(x => x.SsiWorkingHour)
                .HasColumnName("SsiWorkingHour")
                .HasColumnType("decimal(6,2)");
        }
    }
}
