namespace ClassicalMusicShop.Website.Core.Routing
{
    using System.Linq;
    using System.Web.Routing;
    using EPiServer;
    using EPiServer.Commerce.Catalog.ContentTypes;
    using EPiServer.Commerce.Routing;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;
    using EPiServer.ServiceLocation;
    using EPiServer.Web.Routing;
    using Mediachase.Commerce.Catalog;

    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Commerce.Initialization.InitializationModule))]
    public class CommerceRoutingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var referenceConverter = ServiceLocator.Current.GetInstance<ReferenceConverter>();

            var firstCatalog = contentLoader.GetChildren<CatalogContent>(referenceConverter.GetRootLink()).First();
            RouteTable.Routes.RegisterPartialRouter(new HierarchicalCatalogPartialRouter(() => EPiServer.Web.SiteDefinition.Current.StartPage, firstCatalog, false));
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
