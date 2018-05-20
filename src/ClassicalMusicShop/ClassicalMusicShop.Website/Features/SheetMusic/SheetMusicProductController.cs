namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Web.Mvc;
    using Core.AppMode;
    using EPiServer.Web.Mvc;

    public class SheetMusicProductController : ContentController<SheetMusicProduct>
    {
        public ActionResult Index(SheetMusicProduct currentContent)
        {
            var viewPath = GetViewPath(currentContent);

            return this.View(viewPath, currentContent);
        }

        private static string GetViewPath(SheetMusicProduct currentContent)
        {
            Enum.TryParse(currentContent.AppMode, out AppMode appMode);

            string pathBase = "~/Features/SheetMusic/Views/SheetMusicProduct";

            switch (appMode)
            {
                default:
                case AppMode.Mvc:
                    return $"{pathBase}/Index.cshtml";

                case AppMode.Angular:
                    return $"{pathBase}/IndexAngular.cshtml";

                case AppMode.Vue:
                    return $"{pathBase}/IndexVue.cshtml";

                case AppMode.React:
                    return $"{pathBase}/IndexReact.cshtml";
            }
        }
    }
}