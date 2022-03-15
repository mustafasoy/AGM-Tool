using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public class BusinessInfoMap
    {
        public BusinessInfoMap(EntityTypeBuilder<BusinessInfoDto> entity)
        {
            entity.ToTable("BusinessInfos");

            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasMaxLength(256);
            
            entity.Property(x => x.ActivityCode)
                .HasColumnName("ActivityCode")
                .HasMaxLength(256);
            
            entity.Property(x => x.Adress)
                .HasColumnName("Adress")
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

            entity.Property(x => x.Partner)
                .HasColumnName("Partner")
                .HasMaxLength(256);

            entity.Property(x => x.Date)
                .HasColumnName("Date")
                .HasColumnType("date");

            entity.Property(x => x.PublishDate)
                .HasColumnName("PublishDate")
                .HasColumnType("date");

            entity.Property(x => x.TradeNumber)
                .HasColumnName("TradeNumber")
                .HasMaxLength(26);

            entity.Property(x => x.ChamberCommerce)
                .HasColumnName("ChamberCommerce")
                .HasMaxLength(256);

            entity.Property(x => x.TaxOffice)
                .HasColumnName("TaxOffice")
                .HasMaxLength(256);

            entity.Property(x=>x.RegistrationNo)
                .HasColumnName("RegistrationNo")
                .HasMaxLength(26);

            entity.Property(x => x.FoundingCapital)
                .HasColumnName("FoundingCapital");

            entity.Property(x => x.AvaibleCapital)
                .HasColumnName("AvaibleCapital");

            entity.Property(x => x.AvaibleCapital)
                .HasColumnName("AvaibleCapital");

            entity.Property(x => x.IsSME)
                .HasColumnName("IsSME")
                .HasMaxLength(5)
                .HasConversion(x => x.ToString(), x => (Sme)Enum.Parse(typeof(Sme), x));

            entity.Property(x => x.CRSNumber)
                .HasColumnName("CRSNumber")
                .HasMaxLength(20); ;

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
