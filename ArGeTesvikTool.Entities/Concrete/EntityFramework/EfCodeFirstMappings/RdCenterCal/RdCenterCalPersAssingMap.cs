using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal
{
    public class RdCenterCalPersAssingMap
    {
        public RdCenterCalPersAssingMap(EntityTypeBuilder<RdCenterCalPersAssingDto> entity)
        {
            entity.ToTable("RdCenterCalPersAssings");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.IdentityNumber)
                .HasColumnName("IdentityNumber")
                .HasMaxLength(11);

            entity.Property(x => x.RegistrationNo)
                .HasColumnName("RegistrationNo")
                .HasMaxLength(26);

            entity.Property(x => x.NameSurname)
                .HasColumnName("NameSurname")
                .HasMaxLength(256);

            entity.Property(x => x.ProjectCode)
                .HasColumnName("ProjectCode")
                .HasMaxLength(20);

            entity.Property(x => x.ProjectName)
                .HasColumnName("ProjectName")
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
