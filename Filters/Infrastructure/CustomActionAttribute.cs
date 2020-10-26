using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {

        //invoked before the action method is called
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
           if(filterContext.HttpContext.Request.IsLocal)
            {
                //request cancelled setting result property to action result 
                filterContext.Result = new HttpNotFoundResult();
            }
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}