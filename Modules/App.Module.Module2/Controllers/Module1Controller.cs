using System.Web.Mvc;
using App.Module.Module2.Models;

namespace App.Module.Module2.Controllers
{
    public class Module2Controller : Controller
    {
        public ActionResult Index()
        {
            var model = new Module2Model
            {
                Message = "Ping from Module2/Index"
            };
            return View(model);
        }
    }
}