using System;
using System.Web.Mvc;
using MvcContrib.FluentHtml.Behaviors;
using MvcContrib.FluentHtml.Elements;

namespace FluentHtmlExample.Core.FluentHtml
{
    public class ClientValidationMetaDataBehaviour : ThreadSafeBehavior
    {
        private readonly Func<HtmlHelper> htmlHelperFunc;

        public ClientValidationMetaDataBehaviour(Func<HtmlHelper> htmlHelperFunc)
        {
            this.htmlHelperFunc = htmlHelperFunc;
        }

        protected override void DoExecute(IElement element)
        {
            var htmlHelper = htmlHelperFunc();

            if (!ClientValidationEnabled(htmlHelper) && !SupportsModelState(element))
                return;

            var unobtrusiveValidationAttributes = htmlHelper.GetUnobtrusiveValidationAttributes(element.GetAttr("name"));

            foreach (var attribute in unobtrusiveValidationAttributes)
            {
                element.SetAttr(attribute.Key, attribute.Value);
            }
        }

        private bool SupportsModelState(IElement element)
        {
            return element is ISupportsModelState;
        }

        private bool ClientValidationEnabled(HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.ClientValidationEnabled && htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled;
        }
    }
}