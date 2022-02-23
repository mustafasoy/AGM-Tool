using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerson
{
    public class RdCenterPersonInfoMap
    {
        public RdCenterPersonInfoMap(EntityTypeBuilder<RdCenterPersonInfoDto> entity)
        {
            entity.ToTable("RdCenterPersonInfos");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.IdentityNumber)
                .IsRequired()
                .HasColumnName("IdentityNumber")
                .HasMaxLength(11);

            entity.Property(x => x.NameSurname)
                .IsRequired()
                .HasColumnName("NameSurname")
                .HasMaxLength(256);

            entity.Property(x => x.Nationality)
                .HasColumnName("Location")
                .HasMaxLength(50);

            entity.Property(x => x.EducationStatu)
                .HasColumnName("EducationStatu")
                .HasMaxLength(256);

            entity.Property(x => x.GraduateUniversity)
                .HasColumnName("GraduateUniversity")
                .HasMaxLength(256);

            entity.Property(x => x.UniversityDepartmant)
                .HasColumnName("UniversityDepartmant")
                .HasMaxLength(256);

            entity.Property(x => x.PersonPosition)
                .HasColumnName("PersonPosition")
                .HasMaxLength(256);

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