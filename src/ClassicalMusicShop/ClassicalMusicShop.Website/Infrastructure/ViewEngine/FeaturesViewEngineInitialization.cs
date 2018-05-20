namespace ClassicalMusicShop.Website.Infrastructure.ViewEngine
{
    using System.Linq;
    using System.Web.Mvc;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;

    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FeaturesViewEngineInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ViewEngines.Engines.Remove(ViewEngines.Engines.OfType<WebFormViewEngine>().First());
            ViewEngines.Engines.Add(new FeaturesViewEngine());
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}