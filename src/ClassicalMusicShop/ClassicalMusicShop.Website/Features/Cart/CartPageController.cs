namespace ClassicalMusicShop.Website.Features.Cart
{
    using System;
    using System.Web.Mvc;
    using EPiServer.Core;
    using EPiServer.Web.Mvc;
    using EPiServer.Web.Routing;

    [Route(nameof(CartPage))]
    public class CartPageController : PageController<CartPage>
    {
        private readonly UrlResolver _urlResolver;
        public readonly CartService _cartService;

        public CartPageController(UrlResolver urlResolver, CartService cartService)
        {
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            if (cartService == null) throw new ArgumentNullException(nameof(cartService));
            this._urlResolver = urlResolver;
            this._cartService = cartService;
        }

        public  ActionResult Index(CartPage currentPage)
        {
            return this.View("~/Features/Cart/Views/CartPage/Index.cshtml", currentPage);
        }

        [HttpPost]
        [Route(nameof(AddToCart))]
        public ActionResult AddToCart(string code, int quantity, ContentReference currentPageLink)
        {
            // todo: Add to cart

            string url = this._urlResolver.GetUrl(currentPageLink);

            this._cartService.AddToCart(code, quantity);

            return this.Redirect(url);
        }
    }
}