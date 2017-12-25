using System.Web.Mvc;

namespace App.Module.Module3.Areas.Module3Area
{
    public class Module3AreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Module3Area";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Module3Area_default",
                "Module3Area/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "App.Module.Module3.Areas.Module3Area.Controllers" }
            );
        }
    }
}