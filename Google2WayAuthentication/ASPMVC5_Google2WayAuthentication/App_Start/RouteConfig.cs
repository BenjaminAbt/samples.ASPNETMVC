using System.Web.Mvc;
using System.Web.Routing;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication
{
    public class RouteConfig
    {
        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            // Register routes defined by MVCRouteCache
            // https://www.nuget.org/packages/MVCRouteCache/
            Routing.GeneratedRoutesRegistration.Register( routes );
        }
    }
}
