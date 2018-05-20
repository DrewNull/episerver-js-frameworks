namespace ClassicalMusicShop.Website.Features.Seo
{
    using System.ComponentModel.DataAnnotations;
    using EPiServer.Core;
    using Infrastructure;
    using Infrastructure.Models;

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