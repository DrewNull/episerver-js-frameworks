namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Web.Mvc;
    using EPiServer.Web.Mvc;
    using Infrastructure.AppMode;

    public class SheetMusicVariantController : ContentController<SheetMusicVariant>
    {
        private readonly SheetMusicService _sheetMusicService;
        private readonly AppModeService _appModeService;

        public SheetMusicVariantController(SheetMusicService sheetMusicService, AppModeService appModeService)
        {
            if (sheetMusicService == null) throw new ArgumentNullException(nameof(sheetMusicService));
            if (appModeService == null) throw new ArgumentNullException(nameof(appModeService));
            this._sheetMusicService = sheetMusicService;
            this._appModeService = appModeService;
        }

        public ActionResult Index(SheetMusicVariant currentContent)
        {
            var viewModel = this._sheetMusicService.GetViewModel(currentContent);

            var appMode = this._appModeService.GetAppMode(this.HttpContext);

            return this.View(SheetMusicViewPathHelper.GetViewPath(appMode), viewModel);
        }
    }
}