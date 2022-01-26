﻿using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Business.Concrete.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.DataAccess.Concrete.EntityFramework;
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
            builder.RegisterType<BusinessInfoManager>().As<IBusinessInfoService>().SingleInstance();
            builder.RegisterType<EfBusinessInfoDal>().As<IBusinessInfoDal>().SingleInstance(); 
            #endregion
        }
    }
}
