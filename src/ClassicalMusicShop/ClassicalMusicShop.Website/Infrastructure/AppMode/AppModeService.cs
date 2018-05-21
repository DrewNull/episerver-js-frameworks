namespace ClassicalMusicShop.Website.Infrastructure.AppMode
{
    using System;
    using System.Web;

    public class AppModeService
    {
        private const string CookieName = "classical-music-shop-app-mode";

        public AppMode GetAppMode(HttpContextBase httpContext)
        {
            var appMode = AppMode.Mvc;

            var cookie = httpContext.Request.Cookies[CookieName];

            if (cookie != null)
            {
                Enum.TryParse(cookie.Value, out appMode);
            }

            return appMode;
        }

        public void SetAppMode(AppMode appMode, HttpContextBase httpContext)
        {
            httpContext.Response.AppendCookie(new HttpCookie(CookieName, appMode.ToString()));
        }
    }
}