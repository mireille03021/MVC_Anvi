using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ANVI_Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Cart",
                url: "Cart/{action}/{pdid}",
                defaults: new { controller = "Cart", action = "AddToCart", pdid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "BuyItNow",
                url: "Home/BuyItNow/{pdid}",
                defaults: new { controller = "Home", action = "BuyItNow", pdid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProductDetailPage",
                url: "Home/ProductDetailPage/{pid}",
                defaults: new { controller = "Home", action = "ProductDetailPage", pid = 1 }
            );
            routes.MapRoute(
                name: "ProductsPage",
                url: "Home/{action}/{page}",
                defaults: new { controller = "Home", action = "ProductsPage", page = 1 }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
