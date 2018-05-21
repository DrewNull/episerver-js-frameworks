namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Linq;
    using EPiServer;
    using EPiServer.Commerce.Catalog.ContentTypes;
    using EPiServer.Web.Routing;

    public class SheetMusicProductRepository
    {
        private readonly IContentLoader _contentLoader;
        private readonly UrlResolver _urlResolver;

        public SheetMusicProductRepository(IContentLoader contentLoader, UrlResolver urlResolver)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            this._contentLoader = contentLoader;
            this._urlResolver = urlResolver;
        }

        public SheetMusicProductModel GetParent(SheetMusicVariant childVariant)
        {
            var product = childVariant
                .GetParentProducts()
                .Select(x => this._contentLoader.Get<SheetMusicProduct>(x))
                .FirstOrDefault();

            return this.Create(product);
        }

        public SheetMusicProductModel Get(SheetMusicProduct product)
        {
            return this.Create(product);
        }

        private SheetMusicProductModel Create(SheetMusicProduct product)
        {
            var model = new SheetMusicProductModel
            {
                Product = product,
                Url = this._urlResolver.GetUrl(product.ContentLink), 
            };

            return model;
        }
    }
}