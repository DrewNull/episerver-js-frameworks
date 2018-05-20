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
    using EPiServer.Web;

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

        [Display(
            Name = "Composer", 
            GroupName = GroupDefinitions.Content, 
            Order = 1000)]
        public virtual string Composer { get; set; }

        [Display(
            Name = "Opus",
            GroupName = GroupDefinitions.Content,
            Order = 1100)]
        public virtual string Opus { get; set; }

        [Display(
            Name = "Key",
            GroupName = GroupDefinitions.Content,
            Order = 1200)]
        public virtual string Key { get; set; }

        [Display(
            Name = "Number of Movements",
            GroupName = GroupDefinitions.Content,
            Order = 1300)]
        public virtual int MovementCount { get; set; }

        [Display(
            Name = "Movements",
            GroupName = GroupDefinitions.Content,
            Order = 1400)]
        [UIHint(UIHint.Textarea)]
        public virtual string MovementList { get; set; }

        [Display(
            Name = "Year",
            GroupName = GroupDefinitions.Content,
            Order = 1500)]
        public virtual int Year { get; set; }
    }
}