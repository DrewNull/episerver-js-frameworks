namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using Images;

    public class SheetMusicService
    {
        private readonly ImageMediaRepository _imageMediaRepository;
        private readonly SheetMusicProductRepository _sheetMusicProductRepository;
        private readonly SheetMusicVariantRepository _sheetMusicVariantRepository;

        public SheetMusicService(
            ImageMediaRepository imageMediaRepository, 
            SheetMusicProductRepository sheetMusicProductRepository, 
            SheetMusicVariantRepository sheetMusicVariantRepository)
        {
            if (imageMediaRepository == null) throw new ArgumentNullException(nameof(imageMediaRepository));
            if (sheetMusicProductRepository == null) throw new ArgumentNullException(nameof(sheetMusicProductRepository));
            if (sheetMusicVariantRepository == null) throw new ArgumentNullException(nameof(sheetMusicVariantRepository));
            this._imageMediaRepository = imageMediaRepository;
            this._sheetMusicProductRepository = sheetMusicProductRepository;
            this._sheetMusicVariantRepository = sheetMusicVariantRepository;
        }

        public SheetMusicViewModel Get(SheetMusicProduct product)
        {
            var viewModel = new SheetMusicViewModel();



            return viewModel;
        }

        public SheetMusicViewModel Get(SheetMusicVariant variant)
        {
            var viewModel = new SheetMusicViewModel();



            return viewModel;
        }
    }
}