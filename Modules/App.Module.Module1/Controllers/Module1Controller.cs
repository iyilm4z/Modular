using System.Web.Mvc;
using App.Module.Module1.Models;

namespace App.Module.Module1.Controllers
{
    public class Module1Controller : Controller
    {
        public ActionResult Index()
        {
            var model = new Module1Model
            {
                Message = "Ping from Module1/Index"
            };
            return View("~/Modules/App.Module.Module1/Views/Index.cshtml", model);
        }
    }
}