namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Cart;
    using Images;

    public class SheetMusicViewModel
    {
        public SheetMusicViewModel()
        {
            this.Instruments = new List<InstrumentOption>();
            this.AddToCartQuantities = new List<SelectListItem>();
            this.AddToCartInputModel = new AddToCartInputModel();
        }

        public ImageMediaModel MainImage { get; set; }

        public SheetMusicProductModel ProductModel { get; set; }

        public SheetMusicVariantModel VariantModel { get; set; }

        public List<InstrumentOption> Instruments { get; }

        public bool HasVariant => this.VariantModel != null;

        public List<SelectListItem> AddToCartQuantities { get; }

        public AddToCartInputModel AddToCartInputModel { get; }
    }
}