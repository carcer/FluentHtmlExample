using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.FluentHtml.Behaviors;

namespace FluentHtmlExample.Core.FluentHtml
{
    public class StandardBehaviorsContainer<T> : DefaultBehaviorsContainer<T> where T : class
    {
        public override IEnumerable<IBehaviorMarker> GetBehaviors(T model, HtmlHelper<T> htmlHelper, ViewDataDictionary<T> viewData)
        {
            return base.GetDefault(model, htmlHelper, viewData);
        }
    }
}