using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public class GroupInfoMap
    {
        public GroupInfoMap(EntityTypeBuilder<GroupInfoDto> entity)
        {
            entity.ToTable("BusinessGroupInfos");

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
            
            entity.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(256);
            
            entity.Property(x => x.Origin)
                .HasColumnName("Origin")
                .HasMaxLength(50);
            
            entity.Property(x => x.FoundingDate)
                .HasColumnName("FoundingDate")
                .HasColumnType("date");

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
