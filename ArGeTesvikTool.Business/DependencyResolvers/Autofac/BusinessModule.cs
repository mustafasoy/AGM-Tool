using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Business.Concrete.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Business;
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
            #endregion
        }
    }
}
