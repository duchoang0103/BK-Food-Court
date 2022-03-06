using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTLcnpm.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        // GET: Admin/BaseAdmin
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Common.AdminLoginModel)Session[Common.CommonConstants.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "AdminLogin", action = "Login", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}