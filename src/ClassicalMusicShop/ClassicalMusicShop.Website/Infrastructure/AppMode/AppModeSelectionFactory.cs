namespace ClassicalMusicShop.Website.Infrastructure.AppMode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EPiServer.Shell.ObjectEditing;

    public class AppModeSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var appModes = Enum.GetNames(typeof(AppMode));
            var selections = appModes.Select(x => new SelectItem {Text = x, Value = x}).ToList();
            return selections;
        }
    }
}