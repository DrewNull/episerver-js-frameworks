namespace ClassicalMusicShop.Website.Features.Cart
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CartPreviewViewModel
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }
    }
}