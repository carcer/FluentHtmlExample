using System.Collections.Generic;
using System.Web.Mvc;
using FluentHtmlExample.Core.FluentHtml;
using MvcContrib.FluentHtml;
using MvcContrib.FluentHtml.Behaviors;

namespace FluentHtmlExample.Core
{
    public abstract class FluentHtmlPageBaseWeb<TModel> : WebViewPage<TModel>, IViewModelContainer<TModel>, IWantBehaviours<TModel>
        where TModel : class
    {
        private BehaviorsContainer<TModel> viewDataContainer;
        private string htmlNamePrefix;

        public IEnumerable<IBehaviorMarker> Behaviors
        {
            get { return BehaviorMarkers(); }
        }

        private IEnumerable<IBehaviorMarker> BehaviorMarkers()
        {
            return viewDataContainer.GetBehaviors(ViewModel, Html, ViewData);
        }

        public TModel ViewModel
        {
            get { return base.Model; }
        }

        public string HtmlNamePrefix
        {
            get { return htmlNamePrefix; }
            set { htmlNamePrefix = value; }
        }

        HtmlHelper IViewModelContainer<TModel>.Html
        {
            get { return base.Html; }
        }

        protected FluentHtmlPageBaseWeb()
        {
            viewDataContainer = DefaultBehaviorsContainer.GetInstance<TModel>();
        }

        public void SetBehavioursContainer(BehaviorsContainer<TModel> behaviorsContainer)
        {
            viewDataContainer = behaviorsContainer;
        }
    }


    // I'm a naughty marker interface
    public interface IWantBehaviours
    {
    }
}