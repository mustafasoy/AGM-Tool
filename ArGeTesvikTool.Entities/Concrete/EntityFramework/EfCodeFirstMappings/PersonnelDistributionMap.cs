using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public class PersonnelDistributionMap : EntityTypeConfiguration<PersonnelDistributionDto>
    {
        public PersonnelDistributionMap(EntityTypeBuilder<PersonnelDistributionDto> entityTypeBuilder)
        {
            #region Column Properties
            entityTypeBuilder.Property(x => x.Id)
                .HasColumnName("Id");

            entityTypeBuilder.Property(x => x.CompanyUnit)
                .HasColumnName("CompanyUnit")
                .HasMaxLength(10);

            entityTypeBuilder.Property(x => x.PostDoctoral)
                .HasColumnName("PostDoctoral");

            entityTypeBuilder.Property(x => x.Doctoral)
                .HasColumnName("Doctoral");

            entityTypeBuilder.Property(x => x.MasterDegree)
                .HasColumnName("MasterDegree");

            entityTypeBuilder.Property(x => x.BachelorDegree)
                .HasColumnName("BachelorDegree");

            entityTypeBuilder.Property(x => x.AssociateDegree)
                .HasColumnName("AssociateDegree");

            entityTypeBuilder.Property(x => x.HighSchool)
                .HasColumnName("HighSchool");

            entityTypeBuilder.Property(x => x.Total)
                .HasColumnName("Total");
            #endregion
        }
    }
}
