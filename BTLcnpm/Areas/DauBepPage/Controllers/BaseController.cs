using BTLcnpm.Areas.DauBepPage.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTLcnpm.Areas.DauBepPage.Controllers
{
    public class BaseController : Controller
    {
        // GET: DauBepPage/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (CookerLoginSession)Session[Constant.COOKER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "DauBepLogin", action = "Login", Area = "DauBepPage" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}