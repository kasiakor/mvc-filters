using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Filters.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        //called for unauthorised access

        //[Authorize] filter attribute will apply to all action methods
        //[ShowMessage] applies only to this method
        //[OutputCache(Duration=60)] applies only to this method
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
            }
            else
            {
                ModelState.AddModelError(" ", "username or passwor id invalid" );
                return View();
            }
        }
    }
}