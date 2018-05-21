namespace ClassicalMusicShop.Website.Features.Cart
{
    using System;
    using System.Web.Http;

    [Route("api/cart")]
    public class CartApiController : ApiController
    {
        private readonly CartService _cartService;

        public CartApiController(CartService cartService)
        {
            if (cartService == null) throw new ArgumentNullException(nameof(cartService));
            this._cartService = cartService;
        }

        [HttpPost]
        [Route("add-to-cart")]
        public CartPreviewViewModel AddToCart(AddToCartInputModel addToCartInputModel)
        {
            this._cartService.AddToCart(addToCartInputModel.Code, addToCartInputModel.Quantity);

            var preview = this._cartService.GetCartPreview();

            return preview;
        }
    }
}