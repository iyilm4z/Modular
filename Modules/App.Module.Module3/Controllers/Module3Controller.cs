using System.Web.Mvc;
using App.Module.Module3.Models;

namespace App.Module.Module3.Controllers
{
    public class Module3Controller : Controller
    {
        public ActionResult Index()
        {
            var model = new Module3Model
            {
                Message = "Ping from Module3/Index"
            };
            return View(model);
        }
    }
}