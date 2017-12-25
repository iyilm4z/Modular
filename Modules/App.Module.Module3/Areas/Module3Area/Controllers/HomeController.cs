using System.Web.Mvc;
using App.Module.Module3.Areas.Module3Area.Models;

namespace App.Module.Module3.Areas.Module3Area.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Module3AreaModel
            {
                Message = "Ping from Module3Area/Index"
            };
            return View(model);
        }
    }
}