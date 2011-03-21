using System.Web.Mvc;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FluentHtmlExample.Core.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterControllers(container);
            RegisterControllerFinder(container);
            RegisterControllerFactory(container);
        }

        private void RegisterControllerFactory(IWindsorContainer container)
        {
            container.Register(Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>());
        }

        private void RegisterControllerFinder(IWindsorContainer container)
        {
            container.Register(Component.For<IControllerFinder>().AsFactory());
        }

        private void RegisterControllers(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly()
                    .BasedOn<IController>()
                    .Configure(config => config.LifeStyle.Transient.Named(config.Implementation.FullName))
                    .WithService.FirstInterface()
                );
        }
    }
}