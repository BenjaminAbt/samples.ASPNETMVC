using System.Web.Mvc;
using SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Routing;
using SchwabenCode.Web.Mvc.Routing;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index( )
        {
            return Redirect( RouteCache.Get( Url, RouteNames.AccountArea.Account ) );
        }
    }
}