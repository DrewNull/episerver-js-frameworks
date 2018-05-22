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

        public SheetMusicService(
            ImageMediaRepository imageMediaRepository, 
            SheetMusicProductRepository sheetMusicProductRepository, 
            SheetMusicVariantRepository sheetMusicVariantRepository, 
            IPageRouteHelper pageRouteHelper)
        {
            if (imageMediaRepository == null) throw new ArgumentNullException(nameof(imageMediaRepository));
            if (sheetMusicProductRepository == null) throw new ArgumentNullException(nameof(sheetMusicProductRepository));
            if (sheetMusicVariantRepository == null) throw new ArgumentNullException(nameof(sheetMusicVariantRepository));
            if (pageRouteHelper == null) throw new ArgumentNullException(nameof(pageRouteHelper));
            this._imageMediaRepository = imageMediaRepository;
            this._sheetMusicProductRepository = sheetMusicProductRepository;
            this._sheetMusicVariantRepository = sheetMusicVariantRepository;
            this._pageRouteHelper = pageRouteHelper;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicProduct product)
        {
            var viewModel = new SheetMusicViewModel
            {
                ProductViewModel = new SheetMusicProductViewModel
                {
                    ProductModel = this._sheetMusicProductRepository.Get(product), 
                    MainImageModel = this._imageMediaRepository.GetMainImage(product), 
                }
            };

            viewModel.AddToCartQuantities.AddRange(this.GetQuantities());
            viewModel.VariantViewModels.AddRange(this._sheetMusicVariantRepository.GetChildren(product).Select(this.Create).ToList());

            return viewModel;
        }

        public SheetMusicVariantViewModel Create(SheetMusicVariantModel model)
        {
            var viewModel = new SheetMusicVariantViewModel
            {
                VariantModel = model, 
                MainImageModel = this._imageMediaRepository.GetMainImage(model.Variant)
            };

            return viewModel;
        }

        public SheetMusicViewModel GetViewModel(SheetMusicVariant variant)
        {
            var productModel = this._sheetMusicProductRepository.GetParent(variant);

            var viewModel = new SheetMusicViewModel
            {
                ProductViewModel = new SheetMusicProductViewModel
                {
                    ProductModel = productModel,
                    MainImageModel = this._imageMediaRepository.GetMainImage(productModel.Product)
                },
                SelectedVariantCode = variant.Code, 
            };

            viewModel.AddToCartQuantities.AddRange(this.GetQuantities());
            viewModel.AddToCartInputModel.Quantity = 1;
            viewModel.AddToCartInputModel.Code = variant.Code;
            viewModel.AddToCartInputModel.CurrentPageLink = this._pageRouteHelper.ContentLink;
            viewModel.VariantViewModels.AddRange(this._sheetMusicVariantRepository.GetChildren(productModel.Product).Select(this.Create));

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
    }
}