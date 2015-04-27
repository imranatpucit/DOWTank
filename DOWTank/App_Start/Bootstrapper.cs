using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using DOWTank.Common;
using DOWTank.Core;
using DOWTank.Core.Service;
using DOWTank.Custom;

namespace DOWTank.App_Start
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureAutofacContainer();
        }

        public static void ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();
            ConfigureContainer(containerBuilder);

            containerBuilder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());
            containerBuilder.RegisterFilterProvider();
            IContainer container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DOWTankEntities>().AsSelf().InstancePerRequest();
            containerBuilder.RegisterType<UtilityService>().As<IUtilityService>().PropertiesAutowired().InstancePerRequest();
            containerBuilder.RegisterType<SharedFunctions>().As<ISharedFunctions>().PropertiesAutowired().InstancePerRequest();

            containerBuilder.RegisterType<UserManager>().AsSelf().PropertiesAutowired().InstancePerRequest();
           // containerBuilder.RegisterType<ClaimsAuthorizeAttribute>().PropertiesAutowired().InstancePerRequest();

        }
    }
}