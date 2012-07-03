using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using RouteTranslation.Infrastructure;

namespace RouteTranslation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
          
            routes.MapRouteCamelCase(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "VeryLongControllerName", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}