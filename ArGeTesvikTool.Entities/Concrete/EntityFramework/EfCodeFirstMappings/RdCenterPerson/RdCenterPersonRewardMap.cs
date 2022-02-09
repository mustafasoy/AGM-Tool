using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerson
{
    public class RdCenterPersonRewardMap
    {
        public RdCenterPersonRewardMap(EntityTypeBuilder<RdCenterPersonRewardDto> entity)
        {
            entity.ToTable("RdCenterPersonRewars");

            entity.HasIndex(x => x.Year)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");
            
            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Text)
                .HasColumnName("Text");

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
