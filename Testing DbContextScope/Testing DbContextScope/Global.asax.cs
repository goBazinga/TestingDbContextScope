using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using TestingDbContextScope.Data;
using Mehdime.Entity;

namespace Testing_DbContextScope
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer Container { get; set; }
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();
            builder.RegisterType<AmbientDbContextLocator>().As<IAmbientDbContextLocator>();
            //Register all services
            builder.RegisterAssemblyTypes(Assembly.Load("TestingDbContextScope.Service"))
                .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
