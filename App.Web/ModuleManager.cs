#region Usings

using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using App.Web;

#endregion

[assembly: PreApplicationStartMethod(typeof(ModuleManager), "Initialize")]

namespace App.Web
{
    public class ModuleManager
    {
        #region Consts

        private const string ModulesPath = "~/Modules";
        private const string ShadowCopyPath = "~/Modules/bin";

        #endregion

        #region Methods

        public static void Initialize()
        {
            var modulesFolder = new DirectoryInfo(HostingEnvironment.MapPath(ModulesPath));
            var shadowCopyFolder = new DirectoryInfo(HostingEnvironment.MapPath(ShadowCopyPath));

            Directory.CreateDirectory(modulesFolder.FullName);
            Directory.CreateDirectory(shadowCopyFolder.FullName);

            foreach (var dllFile in shadowCopyFolder.GetFiles("*.dll", SearchOption.AllDirectories))
                dllFile.Delete();

            foreach (var moduleDll in modulesFolder.GetFiles("*.dll", SearchOption.AllDirectories))
            {
                var shadowCopiedModuleFile = new FileInfo(Path.Combine(shadowCopyFolder.FullName, moduleDll.Name));
                File.Copy(moduleDll.FullName, shadowCopiedModuleFile.FullName, true);
            }

            foreach (var assembly in shadowCopyFolder
                .GetFiles("*.dll", SearchOption.AllDirectories)
                .Select(fileInfo => AssemblyName.GetAssemblyName(fileInfo.FullName))
                .Select(assemblyName => Assembly.Load(assemblyName.FullName)))
            {
                BuildManager.AddReferencedAssembly(assembly);
            }
        }

        #endregion
    }
}