using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Business.Concrete.Business;
using ArGeTesvikTool.Business.Concrete.RdCenter;
using ArGeTesvikTool.Business.Concrete.RdCenterPerson;
using ArGeTesvikTool.Business.Concrete.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.DataAccess.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Business;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenter;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterPerson;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterTech;
using ArGeTesvikTool.WebUI.Helpers;
using Autofac;

namespace ArGeTesvikTool.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordSendMail>().As<IMailService>().SingleInstance();

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
            builder.RegisterType<RdCenterFinancialInfoManager>().As<IRdCenterFinancialInfoService>().SingleInstance();
            builder.RegisterType<EfRdCenterFinancialInfoDal>().As<IRdCenterFinancialInfoDal>().SingleInstance();
            #endregion

            #region RdCenterPerson
            builder.RegisterType<RdCenterPersonInfoManager>().As<IRdCenterPersonInfoService>().SingleInstance();
            builder.RegisterType<EfRdCenterPersonInfoDal>().As<IRdCenterPersonInfoDal>().SingleInstance();
            builder.RegisterType<RdCenterPersonRewardManager>().As<IRdCenterPersonRewardService>().SingleInstance();
            builder.RegisterType<EfRdCenterPersonRewardDal>().As<IRdCenterPersonRewardDal>().SingleInstance();
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
            builder.RegisterType<RdCenterTechIntellectualPropertyManager>().As<IRdCenterTechIntellectualPropertyService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechIntellectualPropertyDal>().As<IRdCenterTechIntellectualPropertyDal>().SingleInstance();
            builder.RegisterType<RdCenterTechMentorInfoManager>().As<IRdCenterTechMentorInfoService>().SingleInstance();
            builder.RegisterType<EfRdCenterTechMentorInfoDal>().As<IRdCenterTechMentorInfoDal>().SingleInstance();
            #endregion
        }
    }
}
