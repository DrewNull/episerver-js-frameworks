namespace ClassicalMusicShop.Website.Features.Cart
{
    using System;
    using EPiServer.Commerce.Order;
    using Mediachase.Commerce;
    using Mediachase.Commerce.Catalog;
    using Mediachase.Commerce.Customers;
    using Mediachase.Commerce.Pricing;

    public class CartService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderGroupFactory _orderGroupFactory;
        private readonly IPriceService _priceService;

        public CartService(IOrderRepository orderRepository, IOrderGroupFactory orderGroupFactory, IPriceService priceService)
        {
            if (orderRepository == null) throw new ArgumentNullException(nameof(orderRepository));
            if (orderGroupFactory == null) throw new ArgumentNullException(nameof(orderGroupFactory));
            if (priceService == null) throw new ArgumentNullException(nameof(priceService));
            this._orderRepository = orderRepository;
            this._orderGroupFactory = orderGroupFactory;
            this._priceService = priceService;
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
    }
}