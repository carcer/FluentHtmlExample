using System.Web.Mvc;
using FluentHtmlExample.Models;

namespace FluentHtmlExample.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            ModelState.AddModelError("Username", "Does this make it to the UI");

            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            return View();
        }
    }
}