namespace ClassicalMusicShop.Website.Infrastructure.DependencyInjection
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using System.Web.Mvc;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;
    using EPiServer.ServiceLocation;
    using StructureMap;

    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            var container = context.StructureMap();

            container.Configure(ConfigureContainer);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new StructureMapHttpControllerActivator(context.StructureMap()));
        }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
            //Implementations for custom interfaces can be registered here.
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}