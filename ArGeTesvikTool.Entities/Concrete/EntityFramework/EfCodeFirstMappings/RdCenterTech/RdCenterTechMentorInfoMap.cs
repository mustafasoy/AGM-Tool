using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech
{
    public class RdCenterTechMentorInfoMap
    {
        public RdCenterTechMentorInfoMap(EntityTypeBuilder<RdCenterTechMentorInfoDto> entity)
        {
            entity.ToTable("RdCenterTechMentorInfos");

            entity.Property(x => x.Id)
                .HasColumnName("Id");

            entity.Property(x => x.Year)
                .HasColumnName("Year")
                .HasMaxLength(4);

            entity.Property(x => x.MentorFirmName)
                .HasColumnName("MentorFirmName")
                .HasMaxLength(256);

            entity.Property(x => x.MentorSupport)
                .HasColumnName("MentorSupport");

            entity.Property(x => x.MentorOutput)
                .HasColumnName("MentorOutput");

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