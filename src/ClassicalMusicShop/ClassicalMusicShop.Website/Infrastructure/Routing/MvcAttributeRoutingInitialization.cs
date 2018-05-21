namespace ClassicalMusicShop.Website.Infrastructure.Routing
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;

    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class MvcAttributeRoutingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}