using System.Web.Mvc;
using App.Web.Models;

namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new WebModel
            {
                Message = "Ping from Web/Index"
            };
            return View(model);
        }
    }
}