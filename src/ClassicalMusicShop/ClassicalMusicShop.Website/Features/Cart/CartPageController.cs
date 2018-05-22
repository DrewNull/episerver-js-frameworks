namespace ClassicalMusicShop.Website.Features.Cart
{
    using System;
    using System.Web.Mvc;
    using EPiServer.Web.Mvc;
    using Infrastructure.AppMode;

    [RoutePrefix(nameof(CartPage))]
    public class CartPageController : PageController<CartPage>
    {
        private readonly CartService _cartService;
        private readonly AppModeService _appModeService;

        public CartPageController(CartService cartService, AppModeService appModeService)
        {
            if (cartService == null) throw new ArgumentNullException(nameof(cartService));
            if (appModeService == null) throw new ArgumentNullException(nameof(appModeService));
            this._cartService = cartService;
            this._appModeService = appModeService;
        }

        public  ActionResult Index(CartPage currentPage)
        {
            return this.View("~/Features/Cart/Views/CartPage/Index.cshtml", currentPage);
        }

        [HttpPost]
        [Route(nameof(AddToCart))]
        public ActionResult AddToCart(AddToCartInputModel addToCartInputModel)
        {
            return this.Redirect(
                this._cartService.AddToCart(
                    addToCartInputModel.Code, 
                    addToCartInputModel.Quantity, 
                    addToCartInputModel.CurrentPageLink));
        }

        [Route(nameof(CartPreview))]
        public ActionResult CartPreview()
        {
            return this.View(
                CartPreviewViewPathHelper.GetViewPath(this._appModeService.GetAppMode(this.HttpContext)), 
                this._cartService.GetCartPreview());
        }
    }
}