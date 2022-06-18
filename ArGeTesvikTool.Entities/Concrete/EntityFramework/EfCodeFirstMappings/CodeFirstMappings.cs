using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Index;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Report;
using ArGeTesvikTool.Entities.Concrete.Index;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.Report;
using Microsoft.EntityFrameworkCore;

namespace ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings
{
    public static class CodeFirstMappings
    {
        public static ModelBuilder CreateCodeFirstMapping(ModelBuilder modelBuilder)
        {
            #region Home Db Map
            _ = new FiscalYearMap(modelBuilder.Entity<FiscalYearDto>());
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
            _ = new RdCenterPhysicalAreaMap(modelBuilder.Entity<RdCenterPhysicalAreaDto>());
            _ = new RdCenterAmountMap(modelBuilder.Entity<RdCenterAmountDto>());
            _ = new RdCenterDiscountMap(modelBuilder.Entity<RdCenterDiscountDto>());
            #endregion

            #region RdCenterCal Db Map
            _ = new RdCenterCalPersAttendanceMap(modelBuilder.Entity<RdCenterCalPersAttendanceDto>());
            _ = new RdCenterCalTimeAwayMap(modelBuilder.Entity<RdCenterCalTimeAwayDto>());
            _ = new RdCenterCalPersAssingMap(modelBuilder.Entity<RdCenterCalPersAssingDto>());
            _ = new RdCenterCalPersonnelEntryMap(modelBuilder.Entity<RdCenterCalPersonnelEntryDto>());
            _ = new RdCenterCalPublicHolidayMap(modelBuilder.Entity<RdCenterCalPublicHolidayDto>());
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
            _ = new RdCenterPerformanceDecisionMap(modelBuilder.Entity<RdCenterPerformanceDecisionDto>());
            #endregion

            #region Report Db Map
            _ = new IncomeMap(modelBuilder.Entity<IncomeDto>());
            _ = new SocialSecurityMap(modelBuilder.Entity<SocialSecurityDto>());
            _ = new TeleworkingMap(modelBuilder.Entity<TeleworkingDto>());
            #endregion

            return modelBuilder;
        }
    }
}
