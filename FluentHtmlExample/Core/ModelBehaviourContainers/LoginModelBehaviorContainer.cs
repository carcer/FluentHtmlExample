using System.Collections.Generic;
using System.Web.Mvc;
using FluentHtmlExample.Core.FluentHtml;
using FluentHtmlExample.Models;
using MvcContrib.FluentHtml.Behaviors;

namespace FluentHtmlExample.Core
{
    public class LoginModelBehaviorContainer : DefaultBehaviorsContainer<LoginModel>
    {
        public override IEnumerable<IBehaviorMarker> GetBehaviors(LoginModel model, HtmlHelper<LoginModel> htmlHelper, ViewDataDictionary<LoginModel> viewData)
        {
            yield return new AutoLabelBehavior();
            yield return new ClientValidationMetaDataBehaviour(() => htmlHelper);
        }
    }
}