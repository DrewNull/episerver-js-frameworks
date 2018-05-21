namespace ClassicalMusicShop.Website.Infrastructure.Routing
{
    using System.Web.Http;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;

    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ApiAttributeRoutingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();
            });
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}