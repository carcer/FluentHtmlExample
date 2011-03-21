using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.FluentHtml.Behaviors;

namespace FluentHtmlExample.Core.FluentHtml
{
    public interface BehaviorsContainer<TModel> : BehaviorsContainer where TModel : class
    {
        IEnumerable<IBehaviorMarker> GetBehaviors(TModel model, HtmlHelper<TModel> htmlHelper, ViewDataDictionary<TModel> viewData);
    }

    public interface BehaviorsContainer
    {
        void AddToView(WebViewPage page);
    }
}