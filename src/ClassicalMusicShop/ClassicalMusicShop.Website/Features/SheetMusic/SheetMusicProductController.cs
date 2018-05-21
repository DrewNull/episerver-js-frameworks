namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Web.Mvc;
    using EPiServer.Web.Mvc;

    public class SheetMusicProductController : ContentController<SheetMusicProduct>
    {
        private readonly SheetMusicService _sheetMusicService;

        public SheetMusicProductController(SheetMusicService sheetMusicService)
        {
            if (sheetMusicService == null) throw new ArgumentNullException(nameof(sheetMusicService));
            this._sheetMusicService = sheetMusicService;
        }

        public ActionResult Index(SheetMusicProduct currentContent)
        {
            var viewModel = this._sheetMusicService.GetViewModel(currentContent, this.HttpContext);

            return this.View(
                SheetMusicViewPathHelper.GetViewPath(viewModel.AppMode),
                viewModel);
        }
    }
}