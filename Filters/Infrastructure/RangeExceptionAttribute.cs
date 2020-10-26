using System;
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
                //filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");
                //filterContext.ExceptionHandled = true;

                int val = (int)(((ArgumentOutOfRangeException)filterContext.Exception).ActualValue);
                //Result used by exception filter property tells MVC what to do
                filterContext.Result = new ViewResult
                {
                    ViewName = "RangeError",
                    //int model - the data model to use for the view - val
                    ViewData = new ViewDataDictionary<int>(val)
                };
                    filterContext.ExceptionHandled = true;
                }
            }
        }
    }