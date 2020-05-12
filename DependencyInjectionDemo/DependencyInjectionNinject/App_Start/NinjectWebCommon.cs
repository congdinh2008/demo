using DependencyInjectionDemo.Core;
using DependencyInjectionDemo.Core.Repositories;
using DependencyInjectionDemo.Core.Services;
using DependencyInjectionNinject;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]
namespace DependencyInjectionNinject
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DemoDbContext>().ToSelf().InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IGenericRepository<Book>>().To<GenericRepository<Book>>().InRequestScope();
            kernel.Bind<IGenericRepository<Category>>().To<GenericRepository<Category>>().InRequestScope();
            kernel.Bind<IBookServices>().To<BookServices>().InRequestScope();
            kernel.Bind<ICategoryServices>().To<CategoryServices>().InRequestScope();
        }
    }
}