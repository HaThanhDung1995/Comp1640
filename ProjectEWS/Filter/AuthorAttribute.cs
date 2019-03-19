using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProjectEWS.Entity;

namespace ProjectEWS.Filter
{
    public class AuthorAttribute : AuthorizeAttribute
    {
        public string PermissionNames;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var account = httpContext.Session["User"] as Master;
            var Permission = PermissionNames.Split('|').ToList();
            if (account != null)
            {
                try
                {
                    using (var datacontext = new DataContext())
                    {
                        var roles = datacontext.MasterRoles.Where(mr =>mr.MasterId==account.Id).Select(mr=>mr.Role.Name).ToList();
                        foreach (var role in roles)
                        {
                            foreach (var item in Permission)
                            {
                                if (item.Trim().ToLower() == role.Trim().ToLower())
                                    return true;
                            }

                        }

                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var router = HttpContext.Current.Request.Url.AbsolutePath;

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Admin", Action = "Login", ReturnUrl = router, Message = "You do not have sufficient permissions to access this page !" }));
        }
    }
}