namespace ClassicalMusicShop.Website.Features.Cart
{
    using System;
    using System.Web.Mvc;
    using EPiServer.Web.Mvc;
    using EPiServer.Web.Routing;

    public class CartPageController : PageController<CartPage>
    {
        private readonly UrlResolver _urlResolver;

        public CartPageController(UrlResolver urlResolver)
        {
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            this._urlResolver = urlResolver;
        }

        public ActionResult AddToCart(AddToCartInputModel inputModel)
        {
            // todo: Add to cart

            return this.Redirect(this._urlResolver.GetUrl(inputModel.CurrentPageLink));
        }
    }
}