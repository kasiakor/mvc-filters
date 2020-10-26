using System;
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

        //[RangeException]
        //applying built-in exception filter
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View ="RangeMyError")]
        public string RangeTest(int id)
        {
            //results when filter [RangeException] not applied to RangeTest action method
            // when applied RangeErrorPage will be displayed
            if (id > 100)
            {
                // Home/RangeTest/109    The id value is : 109
                return String.Format("The id value is : {0}", id);
            }
            else
            {
                //blabla, Parameter name: id, Actual value was 99
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }
    }
}