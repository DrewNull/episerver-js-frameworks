namespace ClassicalMusicShop.Website.Features.Cart
{
    using EPiServer.DataAnnotations;
    using Infrastructure;
    using Seo;

    [ContentType(
        DisplayName = "Cart Page",
        GUID = "6041C0D5-22A2-4CEE-85D8-D344D1C7F2CC",
        GroupName = GroupDefinitions.Commerce,
        Description = "Ecommerce shopping cart page")]
    public class CartPage : ContentPage
    {
    }
}