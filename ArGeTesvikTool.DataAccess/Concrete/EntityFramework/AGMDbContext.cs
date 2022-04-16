using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings;
using ArGeTesvikTool.Entities.Concrete.Index;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.Report;
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

        #region Home Db Set
        public DbSet<FiscalYearDto> FiscalYears { get; set; }
        #endregion

        #region Index Db Set
        public DbSet<NewDataDto> NewDatas { get; set; }
        #endregion

        #region Business Db Set
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

        #region RdCenter Db Set
        public DbSet<RdCenterContactDto> RdCenterContracts { get; set; }
        public DbSet<RdCenterInfoDto> RdCenterInfos { get; set; }
        public DbSet<RdCenterSchemaDto> RdCenterSchemas { get; set; }
        public DbSet<RdCenterAreaInfoDto> RdCenterAreaInfos { get; set; }
        public DbSet<RdCenterPhysicalAreaDto> RdPhysicalAreas { get; set; }
        public DbSet<RdCenterAmountDto> RdCenterAmounts { get; set; }
        public DbSet<RdCenterDiscountDto> RdCenterDiscounts { get; set; }
        #endregion

        #region RdCenterCal Db Set
        public DbSet<RdCenterCalPersAttendanceDto> PersonelAttendances { get; set; }
        public DbSet<RdCenterCalPersonnelInfoDto> RdCenterCalPersonnelInfos { get; set; }
        public DbSet<RdCenterCalProjectInfoDto> RdCenterCalProjectInfos { get; set; }
        public DbSet<RdCenterCalTimeAwayDto> RdCenterCalTimeAways { get; set; }
        public DbSet<RdCenterCalPersAssingDto> RdCenterPersAssings { get; set; }
        public DbSet<RdCenterCalPersonnelEntryDto> RdCenterPersonnelEntries { get; set; }
        public DbSet<RdCenterCalPublicHolidayDto> RdCenterCalPublicHolidays { get; set; }
        #endregion

        #region RdCenterPerson Db Set
        public DbSet<RdCenterPersonInfoDto> RdCenterPersonInfos { get; set; }
        public DbSet<RdCenterPersonRewardDto> RdCenterPersonRewards { get; set; }
        public DbSet<RdCenterPersonTimeAwayDto> RdCenterPersonTimeAways { get; set; }
        #endregion

        #region RdCenterTech Db Set
        public DbSet<RdCenterTechAcademicLibraryDto> RdCenterTechAcademicLibraries { get; set; }
        public DbSet<RdCenterTechAttendedEventDto> RdCenterTechAttendedEvents { get; set; }
        public DbSet<RdCenterTechCollaborationDto> RdCenterTechCollaborations { get; set; }
        public DbSet<RdCenterTechProjectDto> RdCenterTechProjects { get; set; }
        public DbSet<RdCenterTechSoftwareDto> RdCenterTechSoftwares { get; set; }
        public DbSet<RdCenterTechProjectManagementDto> RdCenterTechProjectManagements { get; set; }
        public DbSet<RdCenterTechMentorInfoDto> RdCenterTechMentorInfos { get; set; }
        public DbSet<RdCenterTechIntellectualPropertyDto> RdCenterTechIntellectualProperties { get; set; }
        #endregion

        #region RdCenterPerformance Db Set
        public DbSet<RdCenterPerformanceProjectDto> RdCenterPerformanceProjects { get; set; }
        #endregion

        #region Report Db Set
        public DbSet<IncomeDto> Incomes { get; set; }
        public DbSet<SocialSecurityDto> SocialSecurities { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = CodeFirstMappings.CreateCodeFirstMapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
