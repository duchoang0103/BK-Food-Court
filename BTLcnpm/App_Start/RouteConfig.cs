using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTLcnpm
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "BTLcnpm.Controllers" }
            );
           
            routes.MapRoute(
              name: "Product Vendor",
              url: "san-pham/{name}-{vendorId}",
              defaults: new { controller = "Product", action = "ListProductByMenu", id = UrlParameter.Optional },
              namespaces: new[] { "BTLcnpm.Controllers" }
            );

            routes.MapRoute(
              name: "Cart",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "BTLcnpm.Controllers" }
            );

            routes.MapRoute(
              name: "Xoa sp gio hang",
              url: "xoa-sp-gio-hang",
              defaults: new { controller = "Cart", action = "DeleteItem", id = UrlParameter.Optional },
              namespaces: new[] { "BTLcnpm.Controllers" }
            ); 
            routes.MapRoute(
              name: "Xoa gio hang",
              url: "xoa-gio-hang",
              defaults: new { controller = "Cart", action = "DeleteAll", id = UrlParameter.Optional },
              namespaces: new[] { "BTLcnpm.Controllers" }
            );
            routes.MapRoute(
              name: "Cap nhat sp gio hang",
              url: "cap-nhat-sp-gio-hang",
              defaults: new { controller = "Cart", action = "Update", id = UrlParameter.Optional },
              namespaces: new[] { "BTLcnpm.Controllers" }
            );

            routes.MapRoute(
                 name: "Payment",
                 url: "thanh-toan",
                 defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                 namespaces: new[] { "BTLcnpm.Controllers" }
             );
            routes.MapRoute(
                 name: "Recharge",
                 url: "nap-tien",
                 defaults: new { controller = "User", action = "Recharge", id = UrlParameter.Optional },
                 namespaces: new[] { "BTLcnpm.Controllers" }
             );
            
            routes.MapRoute(
                name: "Account info",
                url: "thong-tin-tai-khoan",
                defaults: new { controller = "User", action = "Info", id = UrlParameter.Optional },
                namespaces: new[] { "BTLcnpm.Controllers" }
            );
            routes.MapRoute(
                name: "Bank Account",
                url: "tai-khoan-ngan-hang",
                defaults: new { controller = "User", action = "Bank", id = UrlParameter.Optional },
                namespaces: new[] { "BTLcnpm.Controllers" }
            );
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "BTLcnpm.Controllers" }
            );

            routes.MapRoute(
                name: "dau bep",
                url: "dau-bep",
                defaults: new { controller = "TrangDaubep", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BTLcnpm.Areas.DauBepPage.Controllers" }
            ).DataTokens["area"] = "DauBepPage";

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BTLcnpm.Controllers" }
            );
            
        }
    }
}
