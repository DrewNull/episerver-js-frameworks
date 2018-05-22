namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EPiServer;
    using EPiServer.Commerce.Catalog.ContentTypes;
    using EPiServer.Commerce.Catalog.Linking;
    using EPiServer.Web.Routing;
    using Mediachase.Commerce;
    using Mediachase.Commerce.Catalog;
    using Mediachase.Commerce.Pricing;

    public class SheetMusicVariantRepository
    {
        private readonly IContentLoader _contentLoader;
        private readonly IRelationRepository _relationRepository;
        private readonly IPriceService _priceService;
        private readonly UrlResolver _urlResolver;

        public SheetMusicVariantRepository(
            IContentLoader contentLoader, 
            IRelationRepository relationRepository, 
            IPriceService priceService, 
            UrlResolver urlResolver)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            if (relationRepository == null) throw new ArgumentNullException(nameof(relationRepository));
            if (priceService == null) throw new ArgumentNullException(nameof(priceService));
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            this._contentLoader = contentLoader;
            this._relationRepository = relationRepository;
            this._priceService = priceService;
            this._urlResolver = urlResolver;
        }

        public SheetMusicVariantModel Get(SheetMusicVariant variant)
        {
            return this.Create(variant);
        }

        public IEnumerable<SheetMusicVariantModel> GetChildren(SheetMusicProduct parentProduct)
        {
            var variants = this._contentLoader
                .GetItems(parentProduct.GetVariants(this._relationRepository), parentProduct.Language)
                .Cast<SheetMusicVariant>()
                .ToList();

            var models = variants
                .Select(this.Create)
                .ToList();

            return models;
        }

        private SheetMusicVariantModel Create(SheetMusicVariant variant)
        {
            return new SheetMusicVariantModel
            {
                Variant = variant,
                Price = this.GetPrice(variant), 
                Url = this._urlResolver.GetUrl(variant.ContentLink)
            };
        }

        private decimal GetPrice(SheetMusicVariant variant)
        {
            return this._priceService
                .GetDefaultPrice(MarketId.Default, DateTime.Now, new CatalogKey(variant.Code), Currency.USD)
                .UnitPrice
                .Amount;
        }
    }
}