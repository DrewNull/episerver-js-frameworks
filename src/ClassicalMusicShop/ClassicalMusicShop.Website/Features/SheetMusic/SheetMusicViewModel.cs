namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System.Collections.Generic;
    using EPiServer.Core;
    using Images;
    using Infrastructure.AppMode;

    public class SheetMusicViewModel
    {
        public SheetMusicViewModel()
        {
            this.Instruments = new List<InstrumentOption>();
        }

        public AppMode AppMode { get; set; }

        public ContentReference CurrentPageLink { get; set; }

        public ImageMediaModel MainImage { get; set; }

        public SheetMusicProductModel ProductModel { get; set; }

        public SheetMusicVariantModel VariantModel { get; set; }

        public List<InstrumentOption> Instruments { get; }

        public bool HasVariant => this.VariantModel != null;
    }
}