namespace ClassicalMusicShop.Website.Features.Cart
{
    using System;
    using System.Linq;
    using EPiServer.Commerce.Order;
    using EPiServer.Core;
    using EPiServer.Web.Routing;
    using Mediachase.Commerce;
    using Mediachase.Commerce.Catalog;
    using Mediachase.Commerce.Customers;
    using Mediachase.Commerce.Pricing;

    public class CartService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderGroupFactory _orderGroupFactory;
        private readonly IPriceService _priceService;
        private readonly IOrderGroupCalculator _orderGroupCalculator;
        private readonly UrlResolver _urlResolver;

        public CartService(
            IOrderRepository orderRepository,
            IOrderGroupFactory orderGroupFactory,
            IPriceService priceService,
            IOrderGroupCalculator orderGroupCalculator,
            UrlResolver urlResolver)
        {
            if (orderRepository == null) throw new ArgumentNullException(nameof(orderRepository));
            if (orderGroupFactory == null) throw new ArgumentNullException(nameof(orderGroupFactory));
            if (priceService == null) throw new ArgumentNullException(nameof(priceService));
            if (orderGroupCalculator == null) throw new ArgumentNullException(nameof(orderGroupCalculator));
            if (urlResolver == null) throw new ArgumentNullException(nameof(urlResolver));
            this._orderRepository = orderRepository;
            this._orderGroupFactory = orderGroupFactory;
            this._priceService = priceService;
            this._orderGroupCalculator = orderGroupCalculator;
            this._urlResolver = urlResolver;
        }

        public void AddToCart(string code, int quantity)
        {
            var cart = this._orderRepository.LoadOrCreateCart<ICart>(CustomerContext.Current.CurrentContactId, "Default");

            var lineItem = cart.CreateLineItem(code, this._orderGroupFactory);

            lineItem.Quantity = quantity;

            lineItem.PlacedPrice = this._priceService
                .GetDefaultPrice(MarketId.Default, DateTime.Now, new CatalogKey(code), Currency.USD)
                .UnitPrice
                .Amount;

            cart.AddLineItem(lineItem);

            this._orderRepository.Save(cart);
        }

        public string AddToCart(string code, int quantity, ContentReference currentPageLink)
        {
            this.AddToCart(code, quantity);

            return this._urlResolver.GetUrl(currentPageLink);
        }

        public CartPreviewViewModel GetCartPreview()
        {
            var viewModel = new CartPreviewViewModel();

            var cart = this._orderRepository.LoadOrCreateCart<ICart>(CustomerContext.Current.CurrentContactId, "Default");

            viewModel.Count = (int)cart.GetAllLineItems().Sum(x => x.Quantity);
            viewModel.Amount = cart.GetSubTotal(this._orderGroupCalculator).ToString();

            return viewModel;
        }
    }
}