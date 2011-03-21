using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentHtmlExample.Core.FluentHtml;

namespace FluentHtmlExample.Core.Installers
{
    public class FluentHtmlBehavioursInstaller : IWindsorInstaller
    {
        private readonly Type containerType = typeof(BehaviorsContainer<>);

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromThisAssembly()
                    .BasedOn(containerType)
                    .Configure(config => config.LifeStyle.PerWebRequest)
                );
        }
    }
}