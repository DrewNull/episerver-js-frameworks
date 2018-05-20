namespace ClassicalMusicShop.Website.Core
{
    using System.ComponentModel.DataAnnotations;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;

    [GroupDefinitions]
    public static class GroupDefinitions
    {
        public const string EPiServerCMS_SettingsPanel = SystemTabNames.PageHeader;

        [Display(Order = 100)]
        public const string Content = SystemTabNames.Content;

        [Display(Order = 10000)]
        public const string Advanced = SystemTabNames.Settings;
    }
}