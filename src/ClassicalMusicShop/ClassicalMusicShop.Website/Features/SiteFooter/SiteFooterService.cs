namespace ClassicalMusicShop.Website.Features.SiteFooter
{
    using System;
    using System.Web;
    using EPiServer.Core;
    using EPiServer.Web.Routing;
    using Infrastructure.AppMode;

    public class SiteFooterService
    {
        private readonly UrlResolver _urlResolver;
        private readonly AppModeService _appModeService;
        private readonly IPageRouteHelper _pageRouteHelper;

        public SiteFooterService(UrlResolver urlResolver, AppModeService appModeService, IPageRouteHelper pageRouteHelper)
        {
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            if (appModeService == null) throw new ArgumentNullException(nameof(appModeService));
            if (pageRouteHelper == null) throw new ArgumentNullException(nameof(pageRouteHelper));
            this._urlResolver = urlResolver;
            this._appModeService = appModeService;
            this._pageRouteHelper = pageRouteHelper;
        }

        public string SetAppMode(ContentReference currentPageLink, AppMode appMode, HttpContextBase httpContext)
        {
            this._appModeService.SetAppMode(appMode, httpContext);
            return this._urlResolver.GetUrl(currentPageLink);
        }

        public SiteFooterViewModel GetViewModel(HttpContextBase httpContext)
        {
            var viewModel = new SiteFooterViewModel
            {
                AppMode = this._appModeService.GetAppMode(httpContext),
                CurrentPageLink = this._pageRouteHelper.ContentLink
            };

            return viewModel;
        }
    }
}