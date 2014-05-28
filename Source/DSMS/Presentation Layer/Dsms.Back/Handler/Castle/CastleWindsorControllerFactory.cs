using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace eCC.Back
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
            IEnumerable<Type> controllerTypes =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(IController).IsAssignableFrom(t)
                select t;
            foreach (Type t in controllerTypes)
                container.Register(Component.For(t).LifeStyle.Transient);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                {
                    throw new HttpException(404, "NotFound");
                }
               return (IController)_container.Resolve(controllerType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
            base.ReleaseController(controller);
        }
    }
}