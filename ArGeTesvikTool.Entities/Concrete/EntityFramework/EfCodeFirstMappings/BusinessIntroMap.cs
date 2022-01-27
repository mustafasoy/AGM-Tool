using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public class BusinessIntroMap : EntityTypeConfiguration<BusinessIntroDto>
    {
        public BusinessIntroMap(EntityTypeBuilder<BusinessIntroDto> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.Year)
                .IsUnique();

            #region Column Properties
            entityTypeBuilder.Property(x => x.Id)
                .HasColumnName("Id");

            entityTypeBuilder.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entityTypeBuilder.Property(x => x.Intro)
                .HasColumnName("Intro");
            #endregion
        }
    }
}
