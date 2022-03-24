using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter
{
    public class RdCenterInfoMap
    {
        public RdCenterInfoMap(EntityTypeBuilder<RdCenterInfoDto> entity)
        {
            entity.ToTable("RdCenterInfos");

            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.CreatedDate)
                .HasColumnName("DocReceiptDate")
                .HasColumnType("date");

            entity.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasMaxLength(256);

            entity.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(256);

            entity.Property(x => x.Location)
                .HasColumnName("Location")
                .HasMaxLength(256);

            entity.Property(x => x.CityCode)
                .HasColumnName("CityCode")
                .HasMaxLength(2);

            entity.Property(x => x.CityText)
                .HasColumnName("CityText")
                .HasMaxLength(50);

            entity.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(14);

            entity.Property(x => x.Mail)
                .HasColumnName("Mail")
                .HasMaxLength(256);

            entity.Property(x => x.RegistrationNo)
                .HasColumnName("RegistrationNo")
                .HasMaxLength(26);

            entity.Property(x => x.OfficeArea)
                .HasColumnName("OfficeArea");

            entity.Property(x => x.OtherArea)
                .HasColumnName("OtherArea");

            entity.Property(x => x.TotalArea)
                .HasColumnName("TotalArea");

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
