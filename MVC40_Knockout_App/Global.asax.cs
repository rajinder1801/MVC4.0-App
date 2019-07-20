using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MVC40_Knockout_App.Contracts;
using MVC40_Knockout_App.Services;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC40_Knockout_App
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterAutoFac(GlobalConfiguration.Configuration);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        void RegisterAutoFac(HttpConfiguration config)
        {
            // Setup the Container Builder
            var builder = new ContainerBuilder();

            // Register the controller in scope 
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            // Register types
            builder.RegisterType<EmployeeInfoService>().As<IEmployeeInfoService>().SingleInstance();
            builder.RegisterType<LeaveApplicationService>().SingleInstance();

            // Build the container
            var container = builder.Build();

            // Setup the dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}