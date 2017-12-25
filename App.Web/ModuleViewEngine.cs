using System.Web.Mvc;

namespace App.Web
{
    public class ModuleViewEngine : RazorViewEngine
    {
        private const string ModulesKey = "_module_";

        public ModuleViewEngine()
        {
            var areaViewLocationFormats = new[]
            {
                // default
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                // modules
                $"/Modules/{ModulesKey}/Areas/{{2}}/Views/{{1}}/{{0}}.cshtml",
                $"/Modules/{ModulesKey}/Areas/{{2}}/Views/Shared/{{0}}.cshtml"
            };

            AreaViewLocationFormats = areaViewLocationFormats;
            AreaMasterLocationFormats = areaViewLocationFormats;
            AreaPartialViewLocationFormats = areaViewLocationFormats;

            var viewLocationsFormats = new[]
            {
                // default
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                // modules
                $"/Modules/{ModulesKey}/Views/{{1}}/{{0}}.cshtml",
                $"/Modules/{ModulesKey}/Views/Shared/{{0}}.cshtml"
            };

            ViewLocationFormats = viewLocationsFormats;
            MasterLocationFormats = viewLocationsFormats;
            PartialViewLocationFormats = viewLocationsFormats;

            FileExtensions = new[] { "cshtml" };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var moduleName = controllerContext.Controller.GetType().Assembly.FullName.Split(',')[0];
            partialPath = partialPath.Replace(ModulesKey, moduleName);
            return base.CreatePartialView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var moduleName = controllerContext.Controller.GetType().Assembly.FullName.Split(',')[0];
            viewPath = viewPath.Replace(ModulesKey, moduleName);
            masterPath = masterPath.Replace(ModulesKey, moduleName);
            return base.CreateView(controllerContext, viewPath, masterPath);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            var moduleName = controllerContext.Controller.GetType().Assembly.FullName.Split(',')[0];
            virtualPath = virtualPath.Replace(ModulesKey, moduleName);
            return base.FileExists(controllerContext, virtualPath);
        }
    }
}