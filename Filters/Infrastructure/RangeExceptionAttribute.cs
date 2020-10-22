using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class RangeExceptionAttribute :  FilterAttribute, IExceptionFilter
    {
        //ExceptionContext defines properties to deal with exceptions
        public void OnException(ExceptionContext filterContext)
        {
            if(!filterContext.ExceptionHandled == true &&
                filterContext.Exception  is ArgumentOutOfRangeException)
            {
                filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}