using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal
{
    public class RdCenterCalPersonnelInfoMap
    {
        public RdCenterCalPersonnelInfoMap(EntityTypeBuilder<RdCenterCalPersonnelInfoDto> entity)
        {
            entity.ToTable("RdCenterCalPersonnelInfos");

            entity.HasIndex(x => x.Email)
                .IsUnique();

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(256);

            entity.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(75);

            entity.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(75);

            entity.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(16);

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
