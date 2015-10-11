using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlMinifyExample
{
    public class HtmlMinifyAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Implement attribute behavior
        /// </summary>
        public override void OnActionExecuted( ActionExecutedContext filterContext )
        {
            if ( IsSupportedContentType( filterContext ) )
            {
                filterContext.HttpContext.Response.Filter = new HtmlMinifyStream( filterContext.HttpContext.Response.Filter );
            }
        }

        /// <summary>
        /// Returns troe if filter is not null and content type is html.
        /// </summary>
        private Boolean IsSupportedContentType( ActionExecutedContext filterContext )
        {
            return filterContext.HttpContext.Response.Filter != null && filterContext.HttpContext.Response.ContentType.Equals( "text/html", StringComparison.OrdinalIgnoreCase );
        }
    }
}