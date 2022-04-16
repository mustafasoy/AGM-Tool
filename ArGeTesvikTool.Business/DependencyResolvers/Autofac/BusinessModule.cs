using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Business.Abstract.Home;
using ArGeTesvikTool.Business.Abstract.Index;
using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.Business.Abstract.RdCenterPerformance;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Business.Abstract.Report;
using ArGeTesvikTool.Business.Concrete.Business;
using ArGeTesvikTool.Business.Concrete.Home;
using ArGeTesvikTool.Business.Concrete.Index;
using ArGeTesvikTool.Business.Concrete.RdCenter;
using ArGeTesvikTool.Business.Concrete.RdCenterCal;
using ArGeTesvikTool.Business.Concrete.RdCenterPerformance;
using ArGeTesvikTool.Business.Concrete.RdCenterPerson;
using ArGeTesvikTool.Business.Concrete.RdCenterTech;
using ArGeTesvikTool.Business.Concrete.Report;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.DataAccess.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract.Index;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerformance;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.Report;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Business;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Index;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenter;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterCal;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterPerformance;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterPerson;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterTech;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Report;
using ArGeTesvikTool.WebUI.Helpers;
using Autofac;

namespace ArGeTesvikTool.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailManager>().As<IMailService>().SingleInstance();

            #region Home
            builder.RegisterType<FiscalYearManager>().As<IFiscalYearService>().SingleInstance();
            builder.RegisterType<EfFiscalYearDal>().As<IFiscalYearDal>().SingleInstance();
            #endregion

            #region Index
            builder.RegisterType<NewDataManager>().As<INewDataService>().SingleInstance();
            builder.RegisterType<EfNewDataDal>().As<INewDataDal>().SingleInstance();
            #endregion

            #region Business
            builder.RegisterType<BusinessContactManager>().As<IBusinessContactService>().SingleInstance();
            builder.RegisterType<EfBusinessContactDal>().As<IBusinessContactDal>().SingleInstance();
            builder.RegisterType<BusinessInfoManager>().As<IBusinessInfoService>().SingleInstance();
            builder.RegisterType<EfBusinessInfoDal>().As<IBusinessInfoDal>().SingleInstance();
            builder.RegisterType<BusinessIntroManager>().As<IBusinessIntroService>().SingleInstance();
            builder.RegisterType<EfBusinessIntroDal>().As<IBusinessIntroDal>().SingleInstance();
            builder.RegisterType<GroupInfoManager>().As<IGroupInfoService>().SingleInstance();
            builder.RegisterType<EfGroupInfoDal>().As<IGroupInfoDal>().SingleInstance();
            builder.RegisterType<ShareholderManager>().As<IShareholderService>().SingleInstance();
            builder.RegisterType<EfShareholderDal>().As<IShareholderDal>().SingleInstance();
            builder.RegisterType<PersonnelDistributionManager>().As<IPersonnelDistributionService>().SingleInstance();
            builder.RegisterType<EfPersonnelDistributionDal>().As<IPersonnelDistributionDal>().SingleInstance();
            builder.RegisterType<BusinessSchemaManager>().As<IBusinessSchemaService>().SingleInstance();
            builder.RegisterType<EfBusinessSchemaDal>().As<IBusinessSchemaDal>().SingleInstance();
            builder.RegisterType<StrategyManager>().As<IStrategyService>().SingleInstance();
            builder.RegisterType<EfStrategyDal>().As<IStrategyDal>().SingleInstance();
            builder.RegisterType<BusinessFinancialInfoManager>().As<IBusinessFinancialInfoService>().SingleInstance();
            builder.RegisterType<EfBusinessFinancialInfoDal>().As<IBusinessFinancialInfoDal>().SingleInstance();
            #endregion

            #region RdCenter
            builder.RegisterType<RdCenterContactManager>().As<IRdCenterContactService>().SingleInstance();
            builder.RegisterType<EfRdCenterContactDal>().As<IRdCenterContactInfoDal>().SingleInstance();
            builder.RegisterType<RdCenterInfoManager>().As<IRdCenterInfoService>().SingleInstance();
            builder.RegisterType<EfRdCenterInfoDal>().As<IRdCenterInfoDal>().SingleInstance();
            builder.RegisterType<RdCenterSchemaManager>().As<IRdCenterSchemaService>().SingleInstance();
            builder.RegisterType<EfRdCenterSchemaDal>().As<IRdCenterSchemaDal>().SingleInstance();
            builder.RegisterType<RdCenterAreaInfoManager>().As<IRdCenterAreaInfoService>().SingleInstance();
            builder.RegisterType<EfRdCenterAreaInfoDal>().As<IRdCenterAreaInfoDal>().SingleInstance();
            builder.RegisterType<RdCenterPhysicalAreaManager>().As<IRdCenterPhysicalAreaService>().SingleInstance();
            builder.RegisterType<EfRdCenterPhysicalAreaDal>().As<IRdCenterPhysicalAreaDal>().SingleInstance();
            builder.RegisterType<RdCenterAmountManager>().As<IRdCenterAmountService>().SingleInstance();
            builder.RegisterType<EfRdCenterAmountDal>().As<IRdCenterAmountDal>().SingleInstance();
            builder.RegisterType<RdCenterDiscountManager>().As<IRdCenterDiscountService>().SingleInstance();
            builder.RegisterType<EfRdCenterDiscountDal>().As<IRdCenterDiscountDal>().SingleInstance();
            #endregion

            #region RdCenterCal
            builder.RegisterType<RdCenterCalPersonnelManager>().As<IRdCenterCalPersonnelService>().SingleInstance();
            builder.RegisterType<EfRdCenterCalPersonnelDal>().As<IRdCenterCalPersonnelDal>().SingleInstance();
            builder.RegisterType<RdCenterCalProjectManager>().As<IRdCenterCalProjectService>().SingleInstance();
            builder.RegisterType<EfRdCenterCalProjectDal>().As<IRdCenterCalProjectDal>().SingleInstance();
            builder.RegisterType<RdCenterCalTimeAwayManager>().As<IRdCenterCalTimeAwayService>().SingleInstance();
            builder.RegisterType<EfRdCenterCalTimeAwayDal>().As<IRdCenterCalTimeAwayDal>().SingleInstance();
            builder.RegisterType<RdCenterCalPersAssingManager>().As<IRdCenterCalPersAssingService>().SingleInstance();
            builder.RegisterType<EfRdCenterCalPersAssingDal>().As<IRdCenterCalPersAssingDal>().SingleInstance();
            builder.RegisterType<RdCenterCalPersonnelEntryManager>().As<IRdCenterCalPersonnelEntryService>().SingleInstance();
            builder.RegisterType<EfRdCenterCalPersonnelEntryDal>().As<IRdCenterCalPersonnelEntryDal>().SingleInstance();
            builder.RegisterType<RdCenterCalPublicHolidayManager>().As<IRdCenterCalPublicHolidayService>().SingleInstance();
            builder.RegisterType<EfRdCenterCalPublicHolidayDal>().As<IRdCenterCalPublicHolidayDal>().SingleInstance();
            builder.RegisterType<RdCenterCalPersAttendanceManager>().As<IRdCenterCalPersAttendanceService>().SingleInstance();
            builder.RegisterType<EfRdCenterCalPersAttendanceDal>().As<IRdCenterCalPersAttendanceDal>().SingleInstance();
            #endregion

            #region RdCenterPerson
            builder.RegisterType<RdCenterPersonInfoManager>().As<IRdCenterPersonInfoService>().SingleInstance();
            builder.RegisterType<EfRdCenterPersonInfoDal>().As<IRdCenterPersonInfoDal>().SingleInstance();
            builder.RegisterType<RdCenterPersonRewardManager>().As<IRdCenterPersonRewardService>().SingleInstance();
            builder.RegisterType<EfRdCenterPersonRewardDal>().As<IRdCenterPersonRewardDal>().SingleInstance();
            builder.RegisterType<RdCenterPersonTimeAwayManager>().As<IRdCenterPersonTimeAwayService>().SingleInstance();
            builder.RegisterType<EfRdCenterPersonTimeAwayDal>().As<IRdCenterPersonTimeAwayDal>().SingleInstance();
            #endregion

            #region RdCenterTech
            builder.RegisterType<RdCenterTechCollaborationManager>().As<IRdCenterTechCollaborationService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechCollaborationDal>().As<IRdCenterTechCollaborationDal>().SingleInstance();
            builder.RegisterType<RdCenterTechAcademicLibraryManager>().As<IRdCenterTechAcademicLibraryService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechAcademicLibraryDal>().As<IRdCenterTechAcademicLibraryDal>().SingleInstance();
            builder.RegisterType<RdCenterTechAttendedEventManager>().As<IRdCenterTechAttendedEventService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechAttendedEventDal>().As<IRdCenterTechAttendedEventDal>().SingleInstance();
            builder.RegisterType<RdCenterTechSoftwareManager>().As<IRdCenterTechSoftwareService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechSoftwareDal>().As<IRdCenterTechSoftwareDal>().SingleInstance();
            builder.RegisterType<RdCenterTechProjectManagementManager>().As<IRdCenterTechProjectManagementService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechProjectManagementDal>().As<IRdCenterTechProjectManagementDal>().SingleInstance();
            builder.RegisterType<RdCenterTechProjectManager>().As<IRdCenterTechProjectService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechProjectDal>().As<IRdCenterTechProjectDal>().SingleInstance();
            builder.RegisterType<RdCenterTechIntellectualPropertyManager>().As<IRdCenterTechIntellectualPropertyService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechIntellectualPropertyDal>().As<IRdCenterTechIntellectualPropertyDal>().SingleInstance();
            builder.RegisterType<RdCenterTechMentorInfoManager>().As<IRdCenterTechMentorInfoService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechMentorInfoDal>().As<IRdCenterTechMentorInfoDal>().SingleInstance();
            #endregion

            #region RdCenterPerformance
            builder.RegisterType<RdCenterPerformanceProjectManager>().As<IRdCenterPerformanceProjectService>().SingleInstance();
            builder.RegisterType<EfRdCenterPerformanceProjectDal>().As<IRdCenterPerformanceProjectDal>().SingleInstance();
            #endregion

            #region Report
            builder.RegisterType<IncomeManager>().As<IIncomeService>().SingleInstance();
            builder.RegisterType<EfIncomeDal>().As<IIncomeDal>().SingleInstance();
            builder.RegisterType<SocialSecurityManager>().As<ISocialSecurityService>().SingleInstance();
            builder.RegisterType<EfSocialSecurityDal>().As<ISocialSecurityDal>().SingleInstance();
            builder.RegisterType<ExportExcelManager>().As<IExportExcelService>().SingleInstance();
            #endregion
        }
    }
}
