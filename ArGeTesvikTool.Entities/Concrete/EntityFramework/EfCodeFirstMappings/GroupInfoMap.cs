using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public class GroupInfoMap : EntityTypeConfiguration<GroupInfoDto>
    {
        public GroupInfoMap(EntityTypeBuilder<GroupInfoDto> entityTypeBuilder)
        {
            #region Column Properties
            entityTypeBuilder.Property(x => x.Id)
                .HasColumnName("Id");

            entityTypeBuilder.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasMaxLength(20);

            entityTypeBuilder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(150);

            entityTypeBuilder.Property(x => x.Origin)
                .HasColumnName("Origin")
                .HasMaxLength(30);

            entityTypeBuilder.Property(x => x.FoundingDate)
                .HasColumnName("FoundingDate")
                .HasColumnType("datetime2");
            #endregion

        }
    }
}
