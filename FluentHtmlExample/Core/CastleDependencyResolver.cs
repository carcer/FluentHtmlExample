using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;

namespace FluentHtmlExample.Core
{
    // I'm a bad class/interface, me no have Release method.. 
    // so anything that is resolvable from here should be PerWebRequest
    public class CastleDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public CastleDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType) ? container.ResolveAll(serviceType).Cast<object>() : Enumerable.Empty<object>();
        }
    }
}