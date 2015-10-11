using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlMinifyExample
{
    public class HtmlMinimyFilter : IActionFilter
    {
        public void OnActionExecuting( ActionExecutingContext filterContext )
        {
            // We dont care
        }

        /// <summary>
        /// Minification at the and of the request
        /// </summary>
        public void OnActionExecuted( ActionExecutedContext filterContext )
        {
            if ( IsSupportedContentType( filterContext ) )
            {
                filterContext.HttpContext.Response.Filter = new HtmlMinifyStream( filterContext.HttpContext.Response.Filter );
            }
        }

        /// <summary>
        /// Returns true if filter is not null and content type is html.
        /// </summary>
        private Boolean IsSupportedContentType( ActionExecutedContext filterContext )
        {
            return filterContext.HttpContext.Response.Filter != null && filterContext.HttpContext.Response.ContentType.Equals( "text/html", StringComparison.OrdinalIgnoreCase );
        }
    }
}