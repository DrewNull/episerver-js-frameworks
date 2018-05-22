namespace ClassicalMusicShop.Website.Infrastructure.DependencyInjection
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using StructureMap;

    public class StructureMapHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IContainer _container;

        public StructureMapHttpControllerActivator(IContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            this._container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            return (IHttpController)this._container.GetInstance(controllerType);
        }
    }
}