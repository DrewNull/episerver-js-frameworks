namespace ClassicalMusicShop.Website.Core.ViewEngine
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using System.Web.Mvc;

    public class FeaturesViewEngine : RazorViewEngine
    {
        public FeaturesViewEngine()
        {
            var featureFolderViewLocationFormats = this.FeatureFolders().ToArray();

            this.ViewLocationFormats = this.ViewLocationFormats
                .Union(featureFolderViewLocationFormats)
                .ToArray();

            this.MasterLocationFormats = this.MasterLocationFormats
                .Union(featureFolderViewLocationFormats)
                .ToArray();

            this.PartialViewLocationFormats = this.PartialViewLocationFormats
                .Union(featureFolderViewLocationFormats)
                .ToArray();
        }

        private IEnumerable<string> FeatureFolders()
        {
            var rootFolder = HostingEnvironment.MapPath("~/Features/");
            if (rootFolder == null)
            {
                return Enumerable.Empty<string>();
            }

            var rootDirectory = new DirectoryInfo(rootFolder);

            var controllerPaths = rootDirectory.GetDirectories().Select(dir =>
                $"~/Features/{dir.Name}/Views/{{1}}/{{0}}.cshtml"
            );

            var controllerLessPaths = rootDirectory.GetDirectories()
                .SelectMany(dir => dir.GetDirectories().SelectMany(subDir => new[]
                {
                        $"~/Features/{dir.Name}/Views/{{0}}.cshtml",
                        $"~/Features/{dir.Name}/Views/{subDir.Name}/{{0}}.cshtml"
                }));

            return controllerPaths.Concat(controllerLessPaths);
        }
    }
}