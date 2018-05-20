namespace ClassicalMusicShop.Website.Features.Home
{
    using System.ComponentModel.DataAnnotations;
    using EPiServer.DataAnnotations;
    using EPiServer.Shell.ObjectEditing;
    using Infrastructure;
    using Infrastructure.AppMode;
    using Seo;

    [ContentType(DisplayName = "HomePage", GUID = "b6705acc-5c7a-46ee-8293-3705190afca2", Description = "")]
    public class HomePage : ContentPage
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */

        [Display(
            Name = "App Mode",
            GroupName = GroupDefinitions.Advanced,
            Order = 1000)]
        [SelectOne(SelectionFactoryType = typeof(AppModeSelectionFactory))]
        public virtual string AppMode { get; set; }
    }
}