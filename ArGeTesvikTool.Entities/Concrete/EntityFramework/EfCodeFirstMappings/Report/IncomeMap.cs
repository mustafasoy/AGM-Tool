using ArGeTesvikTool.Entities.Concrete.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Report
{
    public class IncomeMap
    {
        public IncomeMap(EntityTypeBuilder<IncomeDto> entity)
        {
            entity.ToTable("RdCenterTechAttendedEvents");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.PersonnelFullName)
                .HasColumnName("PersonnelFullName")
                .HasMaxLength(512);

            entity.Property(x => x.RegistrationNo)
                .HasColumnName("RegistrationNo")
                .HasMaxLength(26);

            entity.Property(x => x.WorkType)
                .HasColumnName("WorkType")
                .HasMaxLength(20);

            entity.Property(x => x.RdCenterTimeSpend)
                .HasColumnName("RdCenterTimeSpend")
                .HasColumnType("decimal(4,2)");

            entity.Property(x => x.RemoteTimeSpend)
                .HasColumnName("RemoteTimeSpend")
                .HasColumnType("decimal(4,2)");

            entity.Property(x => x.ProjectTimeSpend)
                .HasColumnName("ProjectTimeSpend")
                .HasColumnType("decimal(4,2)");

            entity.Property(x => x.UncentiveTimeSpend)
                .HasColumnName("UncentiveTimeSpend")
                .HasColumnType("decimal(4,2)");

            entity.Property(x => x.NonRdCenterTimeSpend)
                .HasColumnName("NonRdCenterTimeSpend")
                .HasColumnType("decimal(4,2)");

            entity.Property(x => x.NonRdCenterOtherTimeSpend)
                .HasColumnName("NonRdCenterOtherTimeSpend")
                .HasColumnType("decimal(4,2)");

            entity.Property(x => x.AnnualLeaveTimeSpend)
                .HasColumnName("AnnualLeaveTimeSpend")
                .HasColumnType("decimal(4,2)");

            entity.Property(x => x.BaseUsedDay)
                .HasColumnName("BaseUsedDay")
                .HasColumnType("decimal(4,2)");
        }
    }
}
