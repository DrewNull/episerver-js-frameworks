namespace ClassicalMusicShop.Website.Features.SiteFooter
{
    using EPiServer.Core;
    using Infrastructure.AppMode;

    public class SiteFooterViewModel
    {
        public ContentReference CurrentPageLink { get; set; }

        public AppMode AppMode { get; set; }
    }
}