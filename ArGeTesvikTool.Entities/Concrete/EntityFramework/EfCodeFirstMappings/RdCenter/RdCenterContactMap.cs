using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter
{
    public class RdCenterContactMap
    {
        public RdCenterContactMap(EntityTypeBuilder<RdCenterContactDto> entity)
        {
            entity.ToTable("RdCenterContacts");
            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");
            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.IdentityNumber)
                .HasColumnName("IdentityNumber")
                .HasMaxLength(11);
            entity.Property(x => x.Birthday)
                .HasColumnName("Birthday")
                .HasColumnType("date");
            entity.Property(x => x.NameSurname)
                .HasColumnName("NameSurname")
                .HasMaxLength(256);
            entity.Property(x => x.Mail)
                .HasColumnName("Mail")
                .HasMaxLength(256);
            entity.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(11);

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
