using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public class ShareholdersMap : EntityTypeConfiguration<ShareholdersDto>
    {
        public ShareholdersMap(EntityTypeBuilder<ShareholdersDto> entityTypeBuilder)
        {
            #region Column Properties
            entityTypeBuilder.Property(x => x.Id)
                .HasColumnName("Id");

            entityTypeBuilder.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasMaxLength(50);

            entityTypeBuilder.Property(x => x.Share)
                .HasColumnName("Share")
                .HasPrecision(3, 2);

            entityTypeBuilder.Property(x => x.ShareAmount)
                .HasColumnName("ShareAmount");
            #endregion
        }
    }
}
