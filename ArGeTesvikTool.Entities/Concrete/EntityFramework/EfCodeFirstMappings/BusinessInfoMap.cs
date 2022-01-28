using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace ArGeTesvikTool.Entities.EfCodeFirstMappings
{
    public class BusinessInfoMap : EntityTypeConfiguration<BusinessInfoDto>
    {
        public BusinessInfoMap(EntityTypeBuilder<BusinessInfoDto> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.Year)
                .IsUnique();

            #region Column Properties
            entityTypeBuilder.Property(x => x.Id)
                .HasColumnName("Id");

            entityTypeBuilder.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entityTypeBuilder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasMaxLength(100);

            entityTypeBuilder.Property(x => x.ActivityCode)
                .HasColumnName("ActivityCode")
                .HasMaxLength(100);

            entityTypeBuilder.Property(x => x.Adress)
                .HasColumnName("Adress")
                .HasMaxLength(200);

            entityTypeBuilder.Property(x => x.City)
                .HasColumnName("City")
                .HasMaxLength(15);

            entityTypeBuilder.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(10);

            entityTypeBuilder.Property(x => x.Mail)
                .HasColumnName("Mail")
                .HasMaxLength(50);

            entityTypeBuilder.Property(x => x.Partner)
                .HasColumnName("Partner")
                .HasMaxLength(50);

            entityTypeBuilder.Property(x => x.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime2");

            entityTypeBuilder.Property(x => x.PublishDate)
                .HasColumnName("PublishDate")
                .HasColumnType("datetime2");

            entityTypeBuilder.Property(x => x.TradeNumber)
                .HasColumnName("TradeNumber")
                .HasMaxLength(50);

            entityTypeBuilder.Property(x => x.ChamberCommerce)
                .HasColumnName("ChamberCommerce")
                .HasMaxLength(50);

            entityTypeBuilder.Property(x => x.TaxOffice)
                .HasColumnName("TaxOffice")
                .HasMaxLength(20);

            entityTypeBuilder.Property(x => x.FoundingCapital)
                .HasColumnName("FoundingCapital");

            entityTypeBuilder.Property(x => x.AvaibleCapital)
                .HasColumnName("AvaibleCapital");

            entityTypeBuilder.Property(x => x.AvaibleCapital)
                .HasColumnName("AvaibleCapital");

            entityTypeBuilder.Property(x => x.IsSME)
                .HasColumnName("IsSME");

            entityTypeBuilder.Property(x => x.CRSNumber)
                .HasColumnName("CRSNumber");
            #endregion
        }
    }
}
