namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using EPiServer.Web.Routing;
    using Images;
    using Infrastructure.AppMode;

    public class SheetMusicService
    {
        private readonly ImageMediaRepository _imageMediaRepository;
        private readonly SheetMusicProductRepository _sheetMusicProductRepository;
        private readonly SheetMusicVariantRepository _sheetMusicVariantRepository;
        private readonly IPageRouteHelper _pageRouteHelper;
        private readonly UrlResolver _urlResolver;
        private readonly AppModeService _appModeService;

        public SheetMusicService(
            ImageMediaRepository imageMediaRepository, 
            SheetMusicProductRepository sheetMusicProductRepository, 
            SheetMusicVariantRepository sheetMusicVariantRepository, 
            IPageRouteHelper pageRouteHelper, 
            UrlResolver urlResolver, 
            AppModeService appModeService)
        {
            if (imageMediaRepository == null) throw new ArgumentNullException(nameof(imageMediaRepository));
            if (sheetMusicProductRepository == null) throw new ArgumentNullException(nameof(sheetMusicProductRepository));
            if (sheetMusicVariantRepository == null) throw new ArgumentNullException(nameof(sheetMusicVariantRepository));
            if (pageRouteHelper == null) throw new ArgumentNullException(nameof(pageRouteHelper));
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            if (appModeService == null) throw new ArgumentNullException(nameof(appModeService));
            this._imageMediaRepository = imageMediaRepository;
            this._sheetMusicProductRepository = sheetMusicProductRepository;
            this._sheetMusicVariantRepository = sheetMusicVariantRepository;
            this._pageRouteHelper = pageRouteHelper;
            this._urlResolver = urlResolver;
            this._appModeService = appModeService;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicProduct product, HttpContextBase httpContext)
        {
            var viewModel = new SheetMusicViewModel
            {
                AppMode = this._appModeService.GetAppMode(httpContext), 
                CurrentPageLink = this._pageRouteHelper.ContentLink,
                MainImage = this._imageMediaRepository.Get(product.CommerceMediaCollection.FirstOrDefault()?.AssetLink), 
                ProductModel = this._sheetMusicProductRepository.Get(product),
                VariantModel = null
            };

            viewModel.Instruments.AddRange(this.GetInstruments(product));

            return viewModel;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicVariant variant, HttpContextBase httpContext)
        {
            var productModel = this._sheetMusicProductRepository.GetParent(variant);

            var viewModel = new SheetMusicViewModel
            {
                AppMode = this._appModeService.GetAppMode(httpContext),
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
    }
}