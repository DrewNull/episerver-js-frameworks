namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System.ComponentModel.DataAnnotations;
    using EPiServer.Commerce.Catalog.DataAnnotations;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;
    using Infrastructure;
    using Infrastructure.Models;

    [AvailableContentTypes(Availability.None)]
    [CatalogContentType(
        DisplayName = "Sheet Music Variant", 
        GUID = "1D29CA32-698B-475F-9012-BFDD0CD24C70")]
    public class SheetMusicVariant : SiteVariant
    {
        [Display(
            Name = "Instrument",
            GroupName = GroupDefinitions.Content,
            Order = 1000)]
        public virtual string Instrument { get; set; }
    }
}