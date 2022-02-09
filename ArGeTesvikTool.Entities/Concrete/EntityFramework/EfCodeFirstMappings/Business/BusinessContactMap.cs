using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class BusinessContactMap
    {
        public BusinessContactMap(EntityTypeBuilder<BusinessContactDto> entity)
        {
            entity.ToTable("BusinessContacts");

            entity.HasIndex(x => x.Year)
                .IsUnique();

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
