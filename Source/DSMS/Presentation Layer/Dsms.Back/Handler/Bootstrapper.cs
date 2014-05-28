using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Core.Service.IoC;

namespace eCC.Back
{
    public class Bootstrapper
    {
        private static void RegisterServices()
        {
            WindsorRegistrar.RegisterAllFromAssemblies("Dsms.Entity");
            WindsorRegistrar.RegisterAllFromAssemblies("Dsms.Repository");
            WindsorRegistrar.RegisterAllFromAssemblies("Dsms.Service");
            WindsorRegistrar.RegisterAllFromAssemblies("Dsms.Back");
        }

        public static void BootstrapApi(WindsorContainer container)
        {
            container.Register(
                Classes.FromAssemblyNamed("Dsms.Entity")
                    .Pick()
                    .WithService.AllInterfaces()
                    .Configure(o => o.LifestylePerWebRequest()));
            container.Register(
                Classes.FromAssemblyNamed("Dsms.Repository")
                    .Pick()
                    .WithService.AllInterfaces()
                    .Configure(o => o.LifestylePerWebRequest()));
            container.Register(
                Classes.FromAssemblyNamed("Dsms.Service")
                    .Pick()
                    .WithService.AllInterfaces()
                    .Configure(o => o.LifestylePerWebRequest()));
            container.Register(
                Classes.FromAssemblyNamed("Dsms.Back")
                    .Pick()
                    .WithService.AllInterfaces()
                    .Configure(o => o.LifestylePerWebRequest()));

            //Fix resolver for webapi
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn<System.Web.Http.Controllers.IHttpController>()
                    .LifestylePerWebRequest());
        }

        public static void Bootstrap(WindsorContainer container)
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));
            RegisterServices();
            BootstrapApi(container);
        }
    }
}