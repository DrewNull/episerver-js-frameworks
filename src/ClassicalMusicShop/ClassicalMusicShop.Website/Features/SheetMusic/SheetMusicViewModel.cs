namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System.Collections.Generic;
    using EPiServer.Core;
    using Images;

    public class SheetMusicViewModel
    {
        public SheetMusicViewModel()
        {
            this.Instruments = new List<InstrumentOption>();
        }

        public string AppMode { get; set; }

        public ContentReference CurrentPageLink { get; set; }

        public ImageMediaModel MainImage { get; set; }

        public SheetMusicProductModel ProductModel { get; set; }

        public SheetMusicVariantModel VariantModel { get; set; }

        public List<InstrumentOption> Instruments { get; }

        public bool HasVariant => this.VariantModel != null;

        public class InstrumentOption
        {
            public string Text { get; set; }

            public string Url { get; set; }

            public bool IsSelected { get; set; }
        }
    }
}