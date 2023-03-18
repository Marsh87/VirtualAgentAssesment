using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using VirtualAgentAssessment.AutoMapper;
using VirtualAgentAssessment.Domain;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Logic.Services;
using VirtualAgentAssessment.Models;
using VirtualAgentAssessment.Repositories.Interfaces;
using VirtualAgentAssessment.Repositories.Repositories;
using VirtualAgentAssessment.Validators;
using VirtualAssessment.Common;
using VirtualAssessment.Common.Interface;

namespace VirtualAgentAssessment
{
    public class SimpleInjectorBootstrapper
    {
        public static void Boot()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //AutoMapper
            MapperConfiguration config = AutoMapperConfig.Configure();
            container.RegisterInstance<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
            // Register your stuff here
            container.Register<IVirtualAgentContext, VirtualAgentContext>(Lifestyle.Scoped);
            container.Register<IPersonService,PersonService>();
            container.Register<IPersonRepository,PersonRepository>();
            container.Register<IAccountRepository,AccountRepository>();
            container.Register<IAccountService,AccountService>();
            container.Register<IValidator<PersonViewModel>,CreatePersonValidator>();
            container.Register<IValidator<EditPersonViewModel>,EditPersonValidator>();
            container.Register<IValidator<AccountViewModel>,CreateAccountValidator>();
            container.Register<IValidator<CloseAccountViewModel>,CloseAccountValidator>();
            container.Register<IValidator<EditAccountViewModel>,EditAccountValidator>();
            container.Register<IDateTimeProvider,DateTimeProvider>();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}