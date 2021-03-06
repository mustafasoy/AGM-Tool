using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public class ShareholdersMap
    {
        public ShareholdersMap(EntityTypeBuilder<ShareholdersDto> entity)
        {
            entity.ToTable("BusinessShareholders");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasMaxLength(256);

            entity.Property(x => x.CountryCode)
                .HasColumnName("CountryCode")
                .HasMaxLength(4);

            entity.Property(x => x.CountryText)
                .HasColumnName("CountryText")
                .HasMaxLength(50);

            entity.Property(x => x.Share)
                .HasColumnName("Share")
                .HasColumnType("decimal(4,2)");
            
            entity.Property(x => x.ShareAmount)
                .HasColumnName("ShareAmount")
                .HasMaxLength(20);

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
