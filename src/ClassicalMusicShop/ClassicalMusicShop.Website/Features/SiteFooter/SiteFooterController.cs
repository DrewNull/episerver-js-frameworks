namespace ClassicalMusicShop.Website.Features.SiteFooter
{
    using System;
    using System.Web.Mvc;
    using EPiServer.Core;
    using Infrastructure.AppMode;

    public class SiteFooterController : Controller
    {
        private readonly SiteFooterService _siteFooterService;

        public SiteFooterController(SiteFooterService siteFooterService)
        {
            if (siteFooterService == null) throw new ArgumentNullException(nameof(siteFooterService));
            this._siteFooterService = siteFooterService;
        }

        public ActionResult Render()
        {
            return this.View(
                "~/Features/SiteFooter/Views/SiteFooter.cshtml", 
                this._siteFooterService.GetViewModel(this.HttpContext));
        }

        [HttpPost]
        [Route(nameof(SetAppMode))]
        public ActionResult SetAppMode(ContentReference currentPageLink, AppMode appMode)
        {
            return this.Redirect(
                this._siteFooterService.SetAppMode(currentPageLink, appMode, this.HttpContext));
        }
    }
}