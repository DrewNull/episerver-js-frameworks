namespace ClassicalMusicShop.Website.Features.Images
{
    using System.ComponentModel.DataAnnotations;
    using EPiServer.DataAnnotations;
    using EPiServer.Framework.DataAnnotations;
    using EPiServer.Web;
    using Infrastructure;
    using Infrastructure.Models;

    [ContentType(DisplayName = "Image Media", GUID = "9C38C74E-F731-427D-AA0F-BB6C7488AB8B")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageMedia : SiteMedia
    {
        [Display(Name = "Title", GroupName = GroupDefinitions.Content, Order = 1000)]
        public virtual string Title { get; set; }

        [Display(Name = "Description", GroupName = GroupDefinitions.Content, Order = 1100)]
        [UIHint(UIHint.Textarea)]
        public virtual string Description { get; set; }
    }
}