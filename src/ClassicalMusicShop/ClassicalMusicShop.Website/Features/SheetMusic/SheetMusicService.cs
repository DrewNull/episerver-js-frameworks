namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EPiServer.Web.Routing;
    using Home;
    using Images;

    public class SheetMusicService
    {
        private readonly ImageMediaRepository _imageMediaRepository;
        private readonly SheetMusicProductRepository _sheetMusicProductRepository;
        private readonly SheetMusicVariantRepository _sheetMusicVariantRepository;
        private readonly IPageRouteHelper _pageRouteHelper;
        private readonly UrlResolver _urlResolver;
        private readonly HomePageRepository _homePageRepository;

        public SheetMusicService(
            ImageMediaRepository imageMediaRepository, 
            SheetMusicProductRepository sheetMusicProductRepository, 
            SheetMusicVariantRepository sheetMusicVariantRepository, 
            IPageRouteHelper pageRouteHelper, 
            UrlResolver urlResolver, 
            HomePageRepository homePageRepository)
        {
            if (imageMediaRepository == null) throw new ArgumentNullException(nameof(imageMediaRepository));
            if (sheetMusicProductRepository == null) throw new ArgumentNullException(nameof(sheetMusicProductRepository));
            if (sheetMusicVariantRepository == null) throw new ArgumentNullException(nameof(sheetMusicVariantRepository));
            if (pageRouteHelper == null) throw new ArgumentNullException(nameof(pageRouteHelper));
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            if (homePageRepository == null) throw new ArgumentNullException(nameof(homePageRepository));
            this._imageMediaRepository = imageMediaRepository;
            this._sheetMusicProductRepository = sheetMusicProductRepository;
            this._sheetMusicVariantRepository = sheetMusicVariantRepository;
            this._pageRouteHelper = pageRouteHelper;
            this._urlResolver = urlResolver;
            this._homePageRepository = homePageRepository;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicProduct product)
        {
            var viewModel = new SheetMusicViewModel
            {
                AppMode = this.GetAppMode(), 
                CurrentPageLink = this._pageRouteHelper.ContentLink,
                MainImage = this._imageMediaRepository.Get(product.CommerceMediaCollection.FirstOrDefault()?.AssetLink), 
                ProductModel = this._sheetMusicProductRepository.Get(product), 
                VariantModel = null
            };

            viewModel.Instruments.AddRange(this.GetInstruments(product));

            return viewModel;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicVariant variant)
        {
            var productModel = this._sheetMusicProductRepository.GetParent(variant);

            var viewModel = new SheetMusicViewModel
            {
                AppMode = this.GetAppMode(),
                CurrentPageLink = this._pageRouteHelper.ContentLink,
                MainImage = this._imageMediaRepository.Get(variant.CommerceMediaCollection.FirstOrDefault()?.AssetLink),
                ProductModel = productModel,
                VariantModel = this._sheetMusicVariantRepository.Get(variant), 
            };

            viewModel.Instruments.AddRange(this.GetInstruments(productModel.Product, variant.Code));

            return viewModel;
        }

        private IEnumerable<InstrumentOption> GetInstruments(SheetMusicProduct product, string selectedVariantCode = null)
        {
            var variants = this._sheetMusicVariantRepository.GetChildren(product);

            var instruments = variants
                    .Select(x => new InstrumentOption
                {
                    Url = this._urlResolver.GetUrl(x.Variant.ContentLink), 
                    Text = x.Variant.Instrument, 
                    IsSelected = string.Equals(selectedVariantCode, x.Variant.Code, StringComparison.InvariantCultureIgnoreCase), 
                })
                .ToList();

            return instruments;
        }

        private string GetAppMode()
        {
            var homePage = this._homePageRepository.Get();

            return homePage.AppMode;
        }
    }
}