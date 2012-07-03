using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace RouteTranslation.Infrastructure
{
    public class CamelCaseRoute : Route
    {
        public CamelCaseRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler) { }

        public CamelCaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler) { }

        public CamelCaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler) { }

        public CamelCaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler) { }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var path = base.GetVirtualPath(requestContext, values);

            if (path != null)
            {
                path.VirtualPath = Regex.Replace(path.VirtualPath, @"(\B[A-Z])", @"-$1").ToLowerInvariant();               
            }

            return path;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);

            if (routeData != null)
            {
                routeData.Values["controller"] = Regex.Replace((string)routeData.Values["controller"], @"-([a-z])", @"$1");
                routeData.Values["action"] = Regex.Replace((string)routeData.Values["action"], @"-([a-z])", @"$1");
            }

            return routeData;
        }
    }
}