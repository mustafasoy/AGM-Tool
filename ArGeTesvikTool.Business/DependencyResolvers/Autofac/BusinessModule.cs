using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.WebUI.Helpers;
using Autofac;

namespace ArGeTesvikTool.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordSendMail>().As<IMailService>().SingleInstance();
        }
    }
}
