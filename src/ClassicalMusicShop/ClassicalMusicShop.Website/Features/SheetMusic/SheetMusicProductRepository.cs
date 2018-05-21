namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EPiServer;
    using EPiServer.Commerce.Catalog.ContentTypes;
    using EPiServer.Commerce.Catalog.Linking;

    public class SheetMusicProductRepository
    {
        private readonly IContentLoader _contentLoader;
        private readonly IRelationRepository _relationRepository;

        public SheetMusicProductRepository(IContentLoader contentLoader, IRelationRepository relationRepository)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            if (relationRepository == null) throw new ArgumentNullException(nameof(relationRepository));
            this._contentLoader = contentLoader;
            this._relationRepository = relationRepository;
        }

        public SheetMusicProductModel GetParent(SheetMusicVariant childVariant)
        {
            var product = childVariant
                .GetParentProducts()
                .Select(x => this._contentLoader.Get<SheetMusicProduct>(x))
                .FirstOrDefault();

            return this.Create(product);
        }

        public SheetMusicProductModel Get(SheetMusicProduct product)
        {
            return this.Create(product);
        }

        private SheetMusicProductModel Create(SheetMusicProduct product)
        {
            var model = new SheetMusicProductModel
            {
                Product = product,
            };

            model.Movements.AddRange(this.GetMovements(product));

            return model;
        }

        private IEnumerable<string> GetMovements(SheetMusicProduct product)
        {
            return product.MovementList.Split('\n').ToList();
        }
    }
}