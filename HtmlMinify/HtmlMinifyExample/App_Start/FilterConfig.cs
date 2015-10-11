using System.Web;
using System.Web.Mvc;

namespace HtmlMinifyExample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute( ) );

            //// Filter for Performance
            filters.Add( new HtmlMinifyAttribute( ) );

            // Filter for Performance
            filters.Add( new PerformanceMessureFilter( ) );

        }
    }
}
