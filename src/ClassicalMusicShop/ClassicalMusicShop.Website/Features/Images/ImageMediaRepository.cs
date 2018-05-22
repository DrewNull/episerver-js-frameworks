namespace ClassicalMusicShop.Website.Features.Images
{
    using System;
    using System.Linq;
    using EPiServer;
    using EPiServer.Commerce.Catalog.ContentTypes;
    using EPiServer.Core;
    using EPiServer.Web.Routing;

    public class ImageMediaRepository
    {
        private readonly IContentLoader _contentLoader;
        private readonly UrlResolver _urlResolver;

        public ImageMediaRepository(IContentLoader contentLoader, UrlResolver urlResolver)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            this._contentLoader = contentLoader;
            this._urlResolver = urlResolver;
        }

        public ImageMediaModel Get(ContentReference contentLink)
        {
            var model = new ImageMediaModel
            {
                Media = this._contentLoader.Get<ImageMedia>(contentLink), 
                Url = this._urlResolver.GetUrl(contentLink)
            };

            return model;
        }

        public ImageMediaModel GetMainImage(EntryContentBase entryContent)
        {
            return this.Get(entryContent.CommerceMediaCollection.FirstOrDefault()?.AssetLink);
        }
    }
}