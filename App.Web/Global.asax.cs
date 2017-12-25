using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new[] { "App.Web.Controllers" }
            );
        }
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            var moduleViewEngine = new ModuleViewEngine();
            ViewEngines.Engines.Add(moduleViewEngine);

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}