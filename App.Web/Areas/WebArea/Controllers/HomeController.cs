using System.Web.Mvc;
using App.Web.Areas.WebArea.Models;

namespace App.Web.Areas.WebArea.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new WebAreaModel
            {
                Message = "Ping from WebArea/Index"
            };
            return View(model);
        }
    }
}