using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ASPMVC5_Google2WayAuthentication;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
