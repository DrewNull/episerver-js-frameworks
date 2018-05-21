namespace ClassicalMusicShop.Website.Features.Cart
{
    using System.Runtime.Serialization;
    using EPiServer.Core;

    [DataContract]
    public class AddToCartInputModel
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "currentPageLink")]
        public ContentReference CurrentPageLink { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
    }
}