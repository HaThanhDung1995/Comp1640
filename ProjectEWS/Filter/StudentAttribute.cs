using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProjectEWS.Entity;

namespace ProjectEWS.Filter
{
    public class StudentAttribute : AuthorizeAttribute
    {
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var account = httpContext.Session["Student"] as Student;
           
            if (account != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var router = HttpContext.Current.Request.Url.AbsolutePath;

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Student", Action = "Login", ReturnUrl = router, Message = "You do not have sufficient permissions to access this page !" }));
        }
    }
}