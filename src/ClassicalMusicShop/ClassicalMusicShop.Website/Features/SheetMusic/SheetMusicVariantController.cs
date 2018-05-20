namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Web.Mvc;
    using EPiServer.Web.Mvc;

    public class SheetMusicVariantController : ContentController<SheetMusicVariant>
    {
        private readonly SheetMusicService _sheetMusicService;

        public SheetMusicVariantController(SheetMusicService sheetMusicService)
        {
            if (sheetMusicService == null) throw new ArgumentNullException(nameof(sheetMusicService));
            this._sheetMusicService = sheetMusicService;
        }

        public ActionResult Index(SheetMusicVariant currentContent)
        {
            var viewModel = this._sheetMusicService.Get(currentContent);

            return this.View(
                SheetMusicViewPathHelper.GetViewPath(viewModel.AppMode), 
                viewModel);
        }
    }
}