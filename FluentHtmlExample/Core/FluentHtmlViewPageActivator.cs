using System;
using System.Web.Mvc;
using Castle.MicroKernel;
using FluentHtmlExample.Core.Exts;
using FluentHtmlExample.Core.FluentHtml;

namespace FluentHtmlExample.Core
{
    public class FluentHtmlViewPageActivator : IViewPageActivator
    {
        private readonly IKernel kernel;

        public FluentHtmlViewPageActivator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            var view = CreateView(type);

            if (!(WantBehaviours(type)))
                return view;

            AttachBehaviorsContainer(type, view);
           
            return view;
        }

        private bool WantBehaviours(Type type)
        {
            return type.BaseType.CanBeCastTo<IWantBehaviours>();
        }

        private void AttachBehaviorsContainer(Type type, WebViewPage view)
        {
            var viewModelType = GetViewModelType(type);
            var containerType = GetBehaviorsContainerType(viewModelType);

            if (!HasContainer(containerType)) return;
            
            var container = GetContainer(containerType);
            container.AddToView(view);
        }

        private BehaviorsContainer GetContainer(Type containerType)
        {
            var resolve = kernel.Resolve(containerType);
            return resolve as BehaviorsContainer;
        }

        private bool HasContainer(Type containerType)
        {
            return kernel.HasComponent(containerType);
        }

        private Type GetBehaviorsContainerType(Type viewModelType)
        {
            return typeof (BehaviorsContainer<>).MakeGenericType(viewModelType);
        }

        private Type GetViewModelType(Type type)
        {
            return type.BaseType.GetGenericArguments()[0];
        }

        private WebViewPage CreateView(Type type)
        {
            // :\~
            return Activator.CreateInstance(type) as WebViewPage;
        }
    }
}