namespace ClassicalMusicShop.Website.Features.Images
{
    using System;
    using EPiServer;
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
    }
}