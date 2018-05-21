namespace ClassicalMusicShop.Website.Features.Home
{
    using System;
    using EPiServer;
    using EPiServer.Core;

    public class HomePageRepository
    {
        private readonly IContentLoader _contentLoader;

        public HomePageRepository(IContentLoader contentLoader)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            this._contentLoader = contentLoader;
        }

        public HomePage Get()
        {
            return this._contentLoader.Get<HomePage>(ContentReference.StartPage);
        }
    }
}