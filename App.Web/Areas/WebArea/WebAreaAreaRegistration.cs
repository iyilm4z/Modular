using System.Web.Mvc;

namespace App.Web.Areas.WebArea
{
    public class WebAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "WebArea";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebArea_default",
                "WebArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "App.Web.Areas.WebArea.Controllers" }
            );
        }
    }
}