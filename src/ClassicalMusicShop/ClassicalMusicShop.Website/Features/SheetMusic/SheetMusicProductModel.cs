namespace ClassicalMusicShop.Website.Features.SheetMusic
{
    using System.Collections.Generic;

    public class SheetMusicProductModel
    {
        public SheetMusicProductModel()
        {
            this.Movements = new List<string>();
        }

        public SheetMusicProduct Product { get; set; }

        public List<string> Movements { get; }
    }
}