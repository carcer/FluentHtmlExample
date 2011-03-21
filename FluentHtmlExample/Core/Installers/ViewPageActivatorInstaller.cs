using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentHtmlExample.Core.FluentHtml;

namespace FluentHtmlExample.Core.Installers
{
    public class ViewPageActivatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IViewPageActivator>().ImplementedBy<FluentHtmlViewPageActivator>(),
                AllTypes.FromThisAssembly().BasedOn(typeof (BehaviorsContainer<>))
                    .Configure(config => config.LifeStyle.PerWebRequest)
                    .WithService.AllInterfaces()
                );
        }
    }
}