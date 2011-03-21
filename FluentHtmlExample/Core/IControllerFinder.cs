using System;
using System.Web.Mvc;

namespace FluentHtmlExample.Core
{
    public interface IControllerFinder
    {
        void Release(IController controller);
        IController GetController(string controllerType);
    }
}