namespace ClassicalMusicShop.Website.Features.Seo
{
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Core.Models;
    using EPiServer.Core;

    public abstract class ContentPage : SitePage
    {
        [Display(
            Name = "Main Content", 
            Description = "The main content of the page", 
            GroupName = GroupDefinitions.Content, 
            Order = 100)]
        public virtual ContentArea MainContent { get; set; }
    }
}