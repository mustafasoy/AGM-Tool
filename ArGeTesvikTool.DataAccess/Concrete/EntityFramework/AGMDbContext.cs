using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Index;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Pacs;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.Index;
using ArGeTesvikTool.Entities.Concrete.Pacs;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework
{
    public class AGMDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var settingPath = Path.GetFullPath(Path.Combine(@"../ArGeTesvikTool.WebUI/appsettings.json"));

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile(settingPath);

            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        }

        #region Home Db Map
        public DbSet<FiscalYearDto> FiscalYears { get; set; }
        #endregion

        #region Pacs
        public DbSet<PersonelAttendanceDto> PersonelAttendances { get; set; }
        #endregion

        #region Index Db Map
        public DbSet<NewDataDto> NewDatas { get; set; }
        #endregion

        #region Business Db Map
        public DbSet<BusinessContactDto> BusinessContracts { get; set; }
        public DbSet<BusinessInfoDto> BusinessInfos { get; set; }
        public DbSet<BusinessIntroDto> BusinessIntros { get; set; }
        public DbSet<GroupInfoDto> GroupInfos { get; set; }
        public DbSet<ShareholdersDto> Shareholders { get; set; }
        public DbSet<PersonnelDistributionDto> PersonnelDistributions { get; set; }
        public DbSet<BusinessSchemaDto> BusinessSchemas { get; set; }
        public DbSet<StrategyDto> Strategies { get; set; }
        public DbSet<BusinessFinancialInfoDto> BusinessFinancialInfos { get; set; }
        #endregion

        #region RdCenter Db Map
        public DbSet<RdCenterContactDto> RdCenterContracts { get; set; }
        public DbSet<RdCenterInfoDto> RdCenterInfos { get; set; }
        public DbSet<RdCenterSchemaDto> RdCenterSchemas { get; set; }
        public DbSet<RdCenterAreaInfoDto> RdCenterAreaInfos { get; set; }
        public DbSet<RdCenterFinancialInfoDto> RdCenterFinancialInfos { get; set; }
        public DbSet<RdCenterPhysicalAreaDto> RdPhysicalAreas { get; set; }
        public DbSet<RdCenterAmountDto> RdCenterAmounts { get; set; }
        public DbSet<RdCenterDiscountDto> RdCenterDiscounts { get; set; }
        #endregion

        #region RdCenterPerson Db Map
        public DbSet<RdCenterPersonInfoDto> RdCenterPersonInfos { get; set; }
        public DbSet<RdCenterPersonRewardDto> RdCenterPersonRewards { get; set; }
        public DbSet<RdCenterPersonTimeAwayDto> RdCenterPersonTimeAways { get; set; }
        #endregion

        #region RdCenterTech Db Map
        public DbSet<RdCenterTechAcademicLibraryDto> RdCenterTechAcademicLibraries { get; set; }
        public DbSet<RdCenterTechAttendedEventDto> RdCenterTechAttendedEvents { get; set; }
        public DbSet<RdCenterTechCollaborationDto> RdCenterTechCollaborations { get; set; }
        public DbSet<RdCenterTechProjectDto> RdCenterTechProjects { get; set; }
        public DbSet<RdCenterTechSoftwareDto> RdCenterTechSoftwares { get; set; }
        public DbSet<RdCenterTechProjectManagementDto> RdCenterTechProjectManagements { get; set; }
        public DbSet<RdCenterTechMentorInfoDto> RdCenterTechMentorInfos { get; set; }
        public DbSet<RdCenterTechIntellectualPropertyDto> RdCenterTechIntellectualProperties { get; set; }
        #endregion

        #region RdCenterPerformance Db Map
        public DbSet<RdCenterPerformanceProjectDto> RdCenterPerformanceProjects { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Home Db Map
            _ = new FiscalYearMap(modelBuilder.Entity<FiscalYearDto>());
            #endregion

            #region Pacs
            _ = new PersonelAttendanceMap(modelBuilder.Entity<PersonelAttendanceDto>());
            #endregion

            #region Index Db Map
            _ = new NewDataMap(modelBuilder.Entity<NewDataDto>());
            #endregion

            #region Business Db Map
            _ = new BusinessContactMap(modelBuilder.Entity<BusinessContactDto>());
            _ = new BusinessInfoMap(modelBuilder.Entity<BusinessInfoDto>());
            _ = new BusinessIntroMap(modelBuilder.Entity<BusinessIntroDto>());
            _ = new GroupInfoMap(modelBuilder.Entity<GroupInfoDto>());
            _ = new ShareholdersMap(modelBuilder.Entity<ShareholdersDto>());
            _ = new PersonnelDistributionMap(modelBuilder.Entity<PersonnelDistributionDto>());
            _ = new BusinessSchemaMap(modelBuilder.Entity<BusinessSchemaDto>());
            _ = new StrategyMap(modelBuilder.Entity<StrategyDto>());
            _ = new BusinessFinancialInfoMap(modelBuilder.Entity<BusinessFinancialInfoDto>());
            #endregion

            #region RdCenter Db Map
            _ = new RdCenterContactMap(modelBuilder.Entity<RdCenterContactDto>());
            _ = new RdCenterInfoMap(modelBuilder.Entity<RdCenterInfoDto>());
            _ = new RdCenterSchemaMap(modelBuilder.Entity<RdCenterSchemaDto>());
            _ = new RdCenterAreaInfoMap(modelBuilder.Entity<RdCenterAreaInfoDto>());
            _ = new RdCenterFinancialInfoMap(modelBuilder.Entity<RdCenterFinancialInfoDto>());
            _ = new RdCenterPhysicalAreaMap(modelBuilder.Entity<RdCenterPhysicalAreaDto>());
            _ = new RdCenterAmountMap(modelBuilder.Entity<RdCenterAmountDto>());
            _ = new RdCenterDiscountMap(modelBuilder.Entity<RdCenterDiscountDto>());
            #endregion

            #region RdCenterPerson Db Map
            _ = new RdCenterPersonInfoMap(modelBuilder.Entity<RdCenterPersonInfoDto>());
            _ = new RdCenterPersonRewardMap(modelBuilder.Entity<RdCenterPersonRewardDto>());
            _ = new RdCenterPersonTimeAwayMap(modelBuilder.Entity<RdCenterPersonTimeAwayDto>());
            #endregion

            #region RdCenterTech Db Map
            _ = new RdCenterTechAcademicLibraryMap(modelBuilder.Entity<RdCenterTechAcademicLibraryDto>());
            _ = new RdCenterTechAttendedEventMap(modelBuilder.Entity<RdCenterTechAttendedEventDto>());
            _ = new RdCenterTechCollaborationMap(modelBuilder.Entity<RdCenterTechCollaborationDto>());
            _ = new RdCenterTechProjectMap(modelBuilder.Entity<RdCenterTechProjectDto>());
            _ = new RdCenterTechSoftwareMap(modelBuilder.Entity<RdCenterTechSoftwareDto>());
            _ = new RdCenterTechProjectManagementMap(modelBuilder.Entity<RdCenterTechProjectManagementDto>());
            _ = new RdCenterTechMentorInfoMap(modelBuilder.Entity<RdCenterTechMentorInfoDto>());
            _ = new RdCenterTechIntellectualPropertyMap(modelBuilder.Entity<RdCenterTechIntellectualPropertyDto>());
            #endregion

            #region RdCenterPerformance Db Map
            _ = new RdCenterPerformanceProjectMap(modelBuilder.Entity<RdCenterPerformanceProjectDto>());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
