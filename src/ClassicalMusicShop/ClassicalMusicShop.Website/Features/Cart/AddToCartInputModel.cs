namespace ClassicalMusicShop.Website.Features.Cart
{
    using EPiServer.Core;

    public class AddToCartInputModel
    {
        public AddToCartInputModel()
        {
            
        }

        public string Code { get; set; }

        public ContentReference CurrentPageLink { get; set; }

        public int Quantity { get; set; }
    }
}