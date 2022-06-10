using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterTechProjectMap
    {
        public RdCenterTechProjectMap(EntityTypeBuilder<RdCenterTechProjectDto> entity)
        {
            entity.ToTable("RdCenterTechProjects");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.ProjectStatu)
                .HasColumnName("ProjectStatu")
                .HasMaxLength(20)
                .HasConversion(x => x.ToString(), x => (ProjectStatu)Enum.Parse(typeof(ProjectStatu), x));

            entity.Property(x => x.ProjectCode)
                .HasColumnName("ProjectCode")
                .HasMaxLength(20);

            entity.Property(x => x.ProjectName)
                .HasColumnName("ProjectName")
                .HasMaxLength(256);

            entity.Property(x => x.ProjectStartDate)
                .HasColumnName("ProjectStartDate")
                .HasColumnType("date");

            entity.Property(x => x.ProjectEndDate)
                .HasColumnName("ProjectEndDate")
                .HasColumnType("date");

            entity.Property(x => x.PersonNumber)
                .HasColumnName("PersonNumber");

            entity.Property(x => x.ProjectDuration)
                .HasColumnName("ProjectDuration")
                .HasMaxLength(4);

            entity.Property(x => x.ProjectFileName)
                .HasColumnName("ProjectFileName");

            entity.Property(x => x.ProjectContent)
                .HasColumnName("ProjectContent");

            entity.Property(x => x.ProjectContentType)
                .HasColumnName("ProjectContentType");

            entity.Property(x => x.NatSupportProgram)
                .HasColumnName("NatSupportProgram")
                .HasMaxLength(100);

            entity.Property(x => x.IntSupportProgram)
                .HasColumnName("IntSupportProgram")
                .HasMaxLength(100);

            entity.Property(x => x.TotalProjectIncome)
                .HasColumnName("TotalProjectIncome")
                .HasMaxLength(20);

            entity.Property(x => x.EquityAmount)
                .HasColumnName("EquityAmount")
                .HasMaxLength(20);

            entity.Property(x => x.SupportAmount)
                .HasColumnName("SupportAmount")
                .HasMaxLength(20);

            entity.Property(x => x.OrderBase)
                .HasColumnName("OrderBase")
                .HasMaxLength(100);

            entity.Property(x => x.ServiceProcurementSubject)
                .HasColumnName("ServiceProcurementSubject")
                .HasMaxLength(100);

            entity.Property(x => x.ServiceProcurement)
                .HasColumnName("ServiceProcurement")
                .HasMaxLength(10)
                .HasConversion(x => x.ToString(), x => (ServiceProcurement)Enum.Parse(typeof(ServiceProcurement), x));

            entity.Property(x => x.ServiceProcurementAmount)
                .HasColumnName("ServiceProcurementAmount")
                .HasMaxLength(20);

            entity.Property(x => x.NatServiceProcurementAmount)
                .HasColumnName("NatServiceProcurementAmount")
                .HasMaxLength(20);

            entity.Property(x => x.IntServiceProcurementAmount)
                .HasColumnName("IntServiceProcurementAmount")
                .HasMaxLength(20);

            entity.Property(x => x.IncomeFileName)
                .HasColumnName("IncomeFileName");

            entity.Property(x => x.IncomeContent)
                .HasColumnName("IncomeContent");

            entity.Property(x => x.IncomeContentType)
                .HasColumnName("IncomeContentType");

            entity.Property(x => x.ProjectSubject)
                .HasColumnName("ProjectSubject")
                .HasMaxLength(100);

            entity.Property(x => x.ProjectSummary)
                .HasColumnName("ProjectSummary")
                .HasMaxLength(100);

            entity.Property(x => x.ProjectRequirement)
                .HasColumnName("ProjectRequirement")
                .HasMaxLength(500);

            entity.Property(x => x.ProjectActivity)
                .HasColumnName("ProjectActivity")
                .HasMaxLength(500);

            entity.Property(x => x.ProjectInnovative)
                .HasColumnName("ProjectInnovative")
                .HasMaxLength(500);

            entity.Property(x => x.ProjectOutput)
                .HasColumnName("ProjectOutput")
                .HasMaxLength(500);

            entity.Property(x => x.DocumentFileName)
                .HasColumnName("DocumentFileName");

            entity.Property(x => x.DocumentContent)
                .HasColumnName("DocumentContent");

            entity.Property(x => x.DocumentContentType)
                .HasColumnName("DocumentContentType");

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
