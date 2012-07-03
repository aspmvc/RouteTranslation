using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace RouteTranslation.Infrastructure
{
    public static class RouteCollectionExtensions
    {
        public static void MapRouteCamelCase(this RouteCollection routes, string name, string url, object defaults)
        {
            routes.MapRouteCamelCase(name, url, defaults, null);
        }

        public static void MapRouteCamelCase(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");

            if (url == null)
                throw new ArgumentNullException("url");

            var route = new CamelCaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints)
            };

            if (String.IsNullOrEmpty(name))
                routes.Add(route);
            else
                routes.Add(name, route);
        }
    }
}