namespace ClassicalMusicShop.Website.Features.ProductCategories
{
    using Core.Models;
    using EPiServer.Commerce.Catalog.DataAnnotations;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;
    using SheetMusic;

    [AvailableContentTypes(Availability.Specific,
        Include = new[]
        {
            typeof(ProductCategory), 
            typeof(SheetMusicProduct), 
        })]
    [CatalogContentType(
        DisplayName = "Product Category", 
        GUID = "ADE2183F-A305-44AA-BCD0-9B3E03B8530A")]
    public class ProductCategory : SiteCategory
    {
        
    }
}