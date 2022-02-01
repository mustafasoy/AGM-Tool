using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.EntityFrameworkCore;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework
{
    public class AGMDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=TR996928-1809;Initial Catalog=AGMDb;Integrated Security=True");
        }


        public DbSet<BusinessContactDto> BusinessContracts { get; set; }
        public DbSet<BusinessInfoDto> BusinessInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Business Contract
            modelBuilder.Entity<BusinessContactDto>(entity =>
            {
                entity.ToTable("BusinessContracts");
                entity.HasIndex(x => x.Year).IsUnique();

                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Year).HasColumnName("Year").HasMaxLength(4);

                entity.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("date");
                entity.Property(x => x.CreatedUserName).HasColumnName("CreatedUserName");
                entity.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("date");
                entity.Property(x => x.ModifedUserName).HasColumnName("ModifedUserName");
            });
            #endregion

            #region Business Info
            modelBuilder.Entity<BusinessInfoDto>(entity =>
            {
                entity.ToTable("BusinessInfos");
                entity.HasIndex(x => x.Year).IsUnique();

                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Year).HasColumnName("Year").HasMaxLength(4);

                entity.Property(x => x.CompanyName).HasColumnName("CompanyName").HasMaxLength(100);
                entity.Property(x => x.ActivityCode).HasColumnName("ActivityCode").HasMaxLength(100);
                entity.Property(x => x.Adress).HasColumnName("Adress").HasMaxLength(200);
                entity.Property(x => x.City).HasColumnName("City").HasMaxLength(15);
                entity.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
                entity.Property(x => x.Mail).HasColumnName("Mail").HasMaxLength(50);
                entity.Property(x => x.Partner).HasColumnName("Partner").HasMaxLength(50);
                entity.Property(x => x.Date).HasColumnName("Date").HasColumnType("date");
                entity.Property(x => x.PublishDate).HasColumnName("PublishDate").HasColumnType("date");
                entity.Property(x => x.TradeNumber).HasColumnName("TradeNumber").HasMaxLength(50);
                entity.Property(x => x.ChamberCommerce).HasColumnName("ChamberCommerce").HasMaxLength(50);
                entity.Property(x => x.TaxOffice).HasColumnName("TaxOffice").HasMaxLength(20);
                entity.Property(x => x.FoundingCapital).HasColumnName("FoundingCapital");
                entity.Property(x => x.AvaibleCapital).HasColumnName("AvaibleCapital");
                entity.Property(x => x.AvaibleCapital).HasColumnName("AvaibleCapital");
                entity.Property(x => x.IsSME).HasColumnName("IsSME");
                entity.Property(x => x.CRSNumber).HasColumnName("CRSNumber");

                entity.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("date");
                entity.Property(x => x.CreatedUserName).HasColumnName("CreatedUserName");
                entity.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("date");
                entity.Property(x => x.ModifedUserName).HasColumnName("ModifedUserName");
            });
            #endregion

            #region Business Intro
            modelBuilder.Entity<BusinessIntroDto>(entity =>
            {
                entity.ToTable("BusinessIntros");
                entity.HasIndex(x => x.Year).IsUnique();

                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Year).HasColumnName("Year").HasMaxLength(4);

                entity.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("date");
                entity.Property(x => x.CreatedUserName).HasColumnName("CreatedUserName");
                entity.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("date");
                entity.Property(x => x.ModifedUserName).HasColumnName("ModifedUserName");
            });
            #endregion

            #region Business Group
            modelBuilder.Entity<GroupInfoDto>(entity =>
            {
                entity.ToTable("GroupInfos");
                entity.HasIndex(x => x.Year).IsUnique();

                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Year).HasColumnName("Year").HasMaxLength(4);

                entity.Property(x => x.CompanyName).HasColumnName("CompanyName");
                entity.Property(x => x.Address).HasColumnName("Address");
                entity.Property(x => x.Origin).HasColumnName("Origin");
                entity.Property(x => x.FoundingDate).HasColumnName("FoundingDate").HasColumnType("date");

                entity.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("date");
                entity.Property(x => x.CreatedUserName).HasColumnName("CreatedUserName");
                entity.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("date");
                entity.Property(x => x.ModifedUserName).HasColumnName("ModifedUserName");
            });
            #endregion

            #region Shareholders
            modelBuilder.Entity<ShareholdersDto>(entity =>
            {
                entity.ToTable("Shareholders");
                entity.HasIndex(x => x.Year).IsUnique();

                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Year).HasColumnName("Year").HasMaxLength(4);

                entity.Property(x => x.CompanyName).HasColumnName("CompanyName");
                entity.Property(x => x.Origin).HasColumnName("Origin").HasMaxLength(15);
                entity.Property(x => x.Share).HasColumnName("Share");
                entity.Property(x => x.ShareAmount).HasColumnName("ShareAmount");

                entity.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("date");
                entity.Property(x => x.CreatedUserName).HasColumnName("CreatedUserName");
                entity.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("date");
                entity.Property(x => x.ModifedUserName).HasColumnName("ModifedUserName");
            });
            #endregion

            #region Personnel Distribution
            modelBuilder.Entity<PersonnelDistributionDto>(entity =>
            {
                entity.ToTable("PersonnelDistributions");
                entity.HasIndex(x => x.Year).IsUnique();

                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Year).HasColumnName("Year").HasMaxLength(4);

                entity.Property(x => x.CompanyUnit).HasColumnName("CompanyUnit");
                entity.Property(x => x.PostDoctoral).HasColumnName("PostDoctoral");
                entity.Property(x => x.Doctoral).HasColumnName("Doctoral");
                entity.Property(x => x.MasterDegree).HasColumnName("MasterDegree");
                entity.Property(x => x.BachelorDegree).HasColumnName("BachelorDegree");
                entity.Property(x => x.AssociateDegree).HasColumnName("AssociateDegree");
                entity.Property(x => x.HighSchool).HasColumnName("HighSchool");
                entity.Property(x => x.Total).HasColumnName("Total");

                entity.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("date");
                entity.Property(x => x.CreatedUserName).HasColumnName("CreatedUserName");
                entity.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("date");
                entity.Property(x => x.ModifedUserName).HasColumnName("ModifedUserName");
            });
            #endregion
        }
    }
}
