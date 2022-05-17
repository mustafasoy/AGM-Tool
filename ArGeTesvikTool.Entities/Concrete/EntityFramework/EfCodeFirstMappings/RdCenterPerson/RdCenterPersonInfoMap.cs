using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerson
{
    public class RdCenterPersonInfoMap
    {
        public RdCenterPersonInfoMap(EntityTypeBuilder<RdCenterPersonInfoDto> entity)
        {
            entity.ToTable("RdCenterPersonInfos");

            entity.HasOne(s => s.User)
                .WithOne(g => g.PersonnelInfo)
                .HasForeignKey<RdCenterPersonInfoDto>(s => s.UserId);

            entity.HasIndex(x => x.RegistrationNo)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(450);

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.IdentityNumber)
                .HasColumnName("IdentityNumber")
                .HasMaxLength(11);

            entity.Property(x => x.NameSurname)
                .HasColumnName("NameSurname")
                .HasMaxLength(256);

            entity.Property(x => x.CountryCode)
                .HasColumnName("CountryCode")
                .HasMaxLength(4);

            entity.Property(x => x.CountryText)
                .HasColumnName("CountryText")
                .HasMaxLength(50);

            entity.Property(x => x.EducationStatu)
                .HasColumnName("EducationStatu")
                .HasMaxLength(25)
                .HasConversion(x => x.ToString(), x => (EducationStatu)Enum.Parse(typeof(EducationStatu), x));

            entity.Property(x => x.GraduateUniversity)
                .HasColumnName("GraduateUniversity")
                .HasMaxLength(256);

            entity.Property(x => x.UniversityDepartmant)
                .HasColumnName("UniversityDepartmant")
                .HasMaxLength(256);

            entity.Property(x => x.MasterUniversity)
                .HasColumnName("MasterUniversity")
                .HasMaxLength(256);

            entity.Property(x => x.MasterDepartmant)
                .HasColumnName("MasterDepartmant")
                .HasMaxLength(256);

            entity.Property(x => x.DoctoralUniversity)
                .HasColumnName("DoctoralUniversity")
                .HasMaxLength(256);

            entity.Property(x => x.DoctoralDepartmant)
                .HasColumnName("DoctoralDepartmant")
                .HasMaxLength(256);

            entity.Property(x => x.PersonPosition)
                .HasColumnName("PersonPosition")
                .HasMaxLength(20)
                .HasConversion(x => x.ToString(), x => (PersonPosition)Enum.Parse(typeof(PersonPosition), x));

            entity.Property(x => x.WorkType)
                .HasColumnName("WorkType")
                .HasMaxLength(20)
                .HasConversion(x => x.ToString(), x => (WorkType)Enum.Parse(typeof(WorkType), x));

            entity.Property(x => x.RegistrationNo)
                .HasColumnName("RegistrationNo")
                .HasMaxLength(26);

            entity.Property(x => x.StartDate)
                .HasColumnName("StartDate")
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