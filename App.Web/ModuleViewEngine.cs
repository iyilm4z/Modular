#region Usings

using System.Web.Mvc;

#endregion

namespace App.Web
{
    public class ModuleViewEngine : RazorViewEngine
    {
        #region Consts

        private const string ModulesKey = "$Module";

        #endregion

        #region Ctors

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

        #endregion

        #region Utils

        private string GetPath(ControllerContext controllerContext, string virtualPath)
        {
            if (string.IsNullOrWhiteSpace(virtualPath))
                return virtualPath;

            var moduleName = controllerContext.Controller.GetType().Assembly.FullName.Split(',')[0];
            return virtualPath.Replace(ModulesKey, moduleName);
        }

        #endregion

        #region Overriding

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            partialPath = GetPath(controllerContext, partialPath);
            return base.CreatePartialView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            viewPath = GetPath(controllerContext, viewPath);
            masterPath = GetPath(controllerContext, masterPath);
            return base.CreateView(controllerContext, viewPath, masterPath);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            virtualPath = GetPath(controllerContext, virtualPath);
            return base.FileExists(controllerContext, virtualPath);
        }

        #endregion
    }
}