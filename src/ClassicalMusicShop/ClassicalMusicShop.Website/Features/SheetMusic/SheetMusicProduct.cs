namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Core.AppMode;
    using Core.Models;
    using EPiServer.Commerce.Catalog.DataAnnotations;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;
    using EPiServer.Shell.ObjectEditing;

    [AvailableContentTypes(Availability.Specific, 
        Include = new []
        {
            typeof(SheetMusicVariant)
        })]
    [CatalogContentType(
        DisplayName = "Sheet Music Product", 
        GUID = "BAA946F4-6CF1-4B04-93CC-E9769244F4AC")]
    public class SheetMusicProduct : SiteProduct
    {
        [Display(
            Name = "App Mode", 
            GroupName = GroupDefinitions.Advanced, 
            Order = 1000)]
        [SelectOne(SelectionFactoryType = typeof(AppModeSelectionFactory))]
        public virtual string AppMode { get; set; }
    }
}