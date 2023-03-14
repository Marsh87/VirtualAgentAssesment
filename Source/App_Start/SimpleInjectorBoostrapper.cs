using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.Web;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using VirtualAgentAssessment.Domain;

namespace VirtualAgentAssessment.App_Start
{
    public class SimpleInjectorBoostrapper
    {
        public static void Boot()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            // Register your stuff here
            container.Register<IVirtualAgentContext, VirtualAgentContext>(Lifestyle.Scoped);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}