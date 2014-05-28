using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using eCC.Back;
using eCC.Back.Handler.Castle;

namespace Dsms.Back
{
    public class WebApiApplication : HttpApplication
    {
        private WindsorContainer _windsorContainer;

        public WebApiApplication()
        {
            _windsorContainer = new WindsorContainer();
        }

        private void InstallDependencies()
        {
            _windsorContainer.Install(FromAssembly.This());
        }

        private void RegisterDependencyResolver()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(_windsorContainer.Kernel);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize Logging
            LoggingHandler.Initialize();

            Bootstrapper.Bootstrap(_windsorContainer);
            RegisterDependencyResolver();
            InstallDependencies();
        }

        protected void Application_End()
        {
            if (_windsorContainer != null)
            {
                _windsorContainer.Dispose();
            }
        }
    }
}
