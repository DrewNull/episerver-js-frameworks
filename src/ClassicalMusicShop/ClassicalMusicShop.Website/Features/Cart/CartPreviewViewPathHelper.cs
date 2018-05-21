namespace ClassicalMusicShop.Website.Features.Cart
{
    using Infrastructure.AppMode;

    public static class CartPreviewViewPathHelper
    {
        public static string GetViewPath(AppMode appMode)
        {
            string pathBase = "~/Features/Cart/Views";

            switch (appMode)
            {
                default:
                case AppMode.Mvc:
                    return $"{pathBase}/CartPreview.cshtml";

                case AppMode.Angular:
                    return $"{pathBase}/CartPreviewAngular.cshtml";

                case AppMode.Vue:
                    return $"{pathBase}/CartPreviewVue.cshtml";

                case AppMode.React:
                    return $"{pathBase}/CartPreviewReact.cshtml";
            }
        }
    }
}