namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using Core.Models;
    using EPiServer.Commerce.Catalog.DataAnnotations;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;

    [AvailableContentTypes(Availability.None)]
    [CatalogContentType(
        DisplayName = "Sheet Music Variant", 
        GUID = "1D29CA32-698B-475F-9012-BFDD0CD24C70")]
    public class SheetMusicVariant : SiteVariant
    {
        
    }
}