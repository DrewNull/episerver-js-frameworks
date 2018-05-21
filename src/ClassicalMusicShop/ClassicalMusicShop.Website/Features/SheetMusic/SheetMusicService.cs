namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using EPiServer.Web.Routing;
    using Images;

    public class SheetMusicService
    {
        private readonly ImageMediaRepository _imageMediaRepository;
        private readonly SheetMusicProductRepository _sheetMusicProductRepository;
        private readonly SheetMusicVariantRepository _sheetMusicVariantRepository;
        private readonly IPageRouteHelper _pageRouteHelper;
        private readonly UrlResolver _urlResolver;

        public SheetMusicService(
            ImageMediaRepository imageMediaRepository, 
            SheetMusicProductRepository sheetMusicProductRepository, 
            SheetMusicVariantRepository sheetMusicVariantRepository, 
            IPageRouteHelper pageRouteHelper, 
            UrlResolver urlResolver)
        {
            if (imageMediaRepository == null) throw new ArgumentNullException(nameof(imageMediaRepository));
            if (sheetMusicProductRepository == null) throw new ArgumentNullException(nameof(sheetMusicProductRepository));
            if (sheetMusicVariantRepository == null) throw new ArgumentNullException(nameof(sheetMusicVariantRepository));
            if (pageRouteHelper == null) throw new ArgumentNullException(nameof(pageRouteHelper));
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            this._imageMediaRepository = imageMediaRepository;
            this._sheetMusicProductRepository = sheetMusicProductRepository;
            this._sheetMusicVariantRepository = sheetMusicVariantRepository;
            this._pageRouteHelper = pageRouteHelper;
            this._urlResolver = urlResolver;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicProduct product)
        {
            var viewModel = new SheetMusicViewModel
            {
                MainImage = this._imageMediaRepository.Get(product.CommerceMediaCollection.FirstOrDefault()?.AssetLink), 
                ProductModel = this._sheetMusicProductRepository.Get(product),
                VariantModel = null, 
            };

            viewModel.Instruments.AddRange(this.GetInstruments(product));
            viewModel.AddToCartQuantities.AddRange(this.GetQuantities());

            return viewModel;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicVariant variant)
        {
            var productModel = this._sheetMusicProductRepository.GetParent(variant);

            var viewModel = new SheetMusicViewModel
            {
                MainImage = this._imageMediaRepository.Get(variant.CommerceMediaCollection.FirstOrDefault()?.AssetLink),
                ProductModel = productModel,
                VariantModel = this._sheetMusicVariantRepository.Get(variant), 
            };

            viewModel.Instruments.AddRange(this.GetInstruments(productModel.Product, variant.Code));
            viewModel.AddToCartQuantities.AddRange(this.GetQuantities());
            viewModel.AddToCartInputModel.Quantity = 1;
            viewModel.AddToCartInputModel.Code = variant.Code;
            viewModel.AddToCartInputModel.CurrentPageLink = this._pageRouteHelper.ContentLink;

            return viewModel;
        }

        private IEnumerable<SelectListItem> GetQuantities()
        {
            var quantities = Enumerable
                .Range(1, 9)
                .Select(x => x.ToString())
                .Select(x => new SelectListItem { Text = x, Value = x })
                .ToList();

            return quantities;
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