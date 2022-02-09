using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework
{
    public class AGMDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=TR996928-1809;Initial Catalog=AGMDb;Integrated Security=True;MultipleActiveResultSets=True;");
        }

        #region #region Business Db Map
        public DbSet<BusinessContactDto> BusinessContracts { get; set; }
        public DbSet<BusinessInfoDto> BusinessInfos { get; set; }
        public DbSet<BusinessIntroDto> BusinessIntros { get; set; }
        public DbSet<GroupInfoDto> GroupInfos { get; set; }
        public DbSet<ShareholdersDto> Shareholders { get; set; }
        public DbSet<PersonnelDistributionDto> PersonnelDistributions { get; set; }
        #endregion

        #region RdCenter Db Map
        public DbSet<RdCenterContactDto> RdCenterContracts { get; set; }
        public DbSet<RdCenterInfoDto> RdCenterInfos { get; set; }
        #endregion

        #region RdCenterPerson Db Map
        public DbSet<RdCenterPersonInfoDto> RdCenterPersonInfos { get; set; }
        public DbSet<RdCenterPersonRewardDto> RdCenterPersonRewards { get; set; }
        #endregion

        #region RdCenterTech Db Map
        public DbSet<RdCenterTechAcademicLibraryDto> RdCenterTechAcademicLibraries { get; set; }
        public DbSet<RdCenterTechAttendedEventDto> RdCenterTechAttendedEvents { get; set; }
        public DbSet<RdCenterTechCollaborationDto> RdCenterTechCollaborations { get; set; }
        public DbSet<RdCenterTechOngoingProjectDto> RdCenterTechCompletedProjects { get; set; }
        public DbSet<RdCenterTechOngoingProjectDto> RdCenterTechOngoingProjects { get; set; }
        public DbSet<RdCenterTechSoftwareDto> RdCenterTechSoftwares { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Business Db Map
            _ = new BusinessContactMap(modelBuilder.Entity<BusinessContactDto>());
            _ = new BusinessInfoMap(modelBuilder.Entity<BusinessInfoDto>());
            _ = new BusinessIntroMap(modelBuilder.Entity<BusinessIntroDto>());
            _ = new GroupInfoMap(modelBuilder.Entity<GroupInfoDto>());
            _ = new ShareholdersMap(modelBuilder.Entity<ShareholdersDto>());
            _ = new PersonnelDistributionMap(modelBuilder.Entity<PersonnelDistributionDto>());
            #endregion

            #region RdCenter Db Map
            _ = new RdCenterContactMap(modelBuilder.Entity<RdCenterContactDto>());
            _ = new RdCenterInfoMap(modelBuilder.Entity<RdCenterInfoDto>());
            #endregion

            #region RdCenterPerson Db Map
            _ = new RdCenterPersonInfoMap(modelBuilder.Entity<RdCenterPersonInfoDto>());
            _ = new RdCenterPersonRewardMap(modelBuilder.Entity<RdCenterPersonRewardDto>());
            #endregion

            #region RdCenterTech Db Map
            _ = new RdCenterTechAcademicLibraryMap(modelBuilder.Entity<RdCenterTechAcademicLibraryDto>());
            _ = new RdCenterTechAttendedEventMap(modelBuilder.Entity<RdCenterTechAttendedEventDto>());
            _ = new RdCenterTechCollaborationMap(modelBuilder.Entity<RdCenterTechCollaborationDto>());
            _ = new RdCenterTechCompletedProjectMap(modelBuilder.Entity<RdCenterTechCompletedProjectDto>());
            _ = new RdCenterTechOngoingProjectMap(modelBuilder.Entity<RdCenterTechOngoingProjectDto>());
            _ = new RdCenterTechSoftwareMap(modelBuilder.Entity<RdCenterTechSoftwareDto>());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
