namespace ClassicalMusicShop.Website.Core.Routing
{
    using System.Web.Routing;
    using EPiServer.Commerce.Routing;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;

    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Commerce.Initialization.InitializationModule))]
    public class CommerceRoutingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            CatalogRouteHelper.MapDefaultHierarchialRouter(RouteTable.Routes, false);
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
