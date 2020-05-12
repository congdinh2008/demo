using Autofac;
using Autofac.Integration.Mvc;
using DependencyInjectionDemo.Core;
using DependencyInjectionDemo.Core.Repositories;
using DependencyInjectionDemo.Core.Services;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DependencyInjectionDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Register();
        }
    }

    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            DependencyInjectionDemo.RegisterDependancies.Register(builder);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }

    public static class RegisterDependancies
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<DemoDbContext>().As<DemoDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(BookServices).Assembly).Where(t => t.Name.EndsWith("Services")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(CategoryServices).Assembly).Where(t => t.Name.EndsWith("Services")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
