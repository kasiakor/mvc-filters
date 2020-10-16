using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize(Users ="admin")]
        // user admin is authenticated using account controller
        // only admin is authorize to invoke index method 
        public string Index()
        {
            return "This is an index action on the home controller";
        }
    }
}