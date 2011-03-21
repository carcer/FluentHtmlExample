using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.FluentHtml.Behaviors;

namespace FluentHtmlExample.Core.FluentHtml
{
    public class DefaultBehaviorsContainer : DefaultBehaviorsContainer<object>
    {
        private DefaultBehaviorsContainer()
        {
        }

        public override IEnumerable<IBehaviorMarker> GetBehaviors(object model, HtmlHelper<object> htmlHelper, ViewDataDictionary<object> viewData)
        {
            yield return new ClientValidationMetaDataBehaviour(() => htmlHelper);
        }

        public static BehaviorsContainer<T> GetInstance<T>() where T : class
        {
            return new StandardBehaviorsContainer<T>();
        }
    }

    public abstract class DefaultBehaviorsContainer<TModel> : BehaviorsContainer<TModel> where TModel : class
    {
        public abstract IEnumerable<IBehaviorMarker> GetBehaviors(TModel model, HtmlHelper<TModel> htmlHelper, ViewDataDictionary<TModel> viewData);

        public void AddToView(WebViewPage page)
        {
            var castPage = page as IWantBehaviours<TModel>;
            if (castPage == null) return;
            AddToViewCore(castPage);
        }

        protected virtual void AddToViewCore(IWantBehaviours<TModel> castPage)
        {
            castPage.SetBehavioursContainer(this);
        }

        protected IEnumerable<IBehaviorMarker> GetDefault(TModel model, HtmlHelper<TModel> htmlHelper, ViewDataDictionary<TModel> viewData)
        {
            yield return new ClientValidationMetaDataBehaviour(() => htmlHelper);
        }
    }
}