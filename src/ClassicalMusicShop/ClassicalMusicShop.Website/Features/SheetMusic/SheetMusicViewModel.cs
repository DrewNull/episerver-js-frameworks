namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Cart;
    using Images;

    public class SheetMusicViewModel
    {
        public SheetMusicViewModel()
        {
            this.AddToCartQuantities = new List<SelectListItem>();
            this.AddToCartInputModel = new AddToCartInputModel();
            this.VariantViewModels = new List<SheetMusicVariantViewModel>();
        }

        public ImageMediaModel MainImage => 
            this.HasVariant 
                ? this.SelectedVariantViewModel.MainImageModel 
                : this.ProductViewModel.MainImageModel;

        public string SelectedVariantCode { get; set; }

        public SheetMusicProductViewModel ProductViewModel { get; set; }

        public SheetMusicVariantViewModel SelectedVariantViewModel =>
            this.VariantViewModels.FirstOrDefault(x => x.VariantModel.Variant.Code == this.SelectedVariantCode);

        public List<SheetMusicVariantViewModel> VariantViewModels { get; }

        public bool HasVariant => this.SelectedVariantViewModel != null;

        public List<SelectListItem> AddToCartQuantities { get; }

        public AddToCartInputModel AddToCartInputModel { get; }
    }
}