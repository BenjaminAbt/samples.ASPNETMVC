using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlMinifyExample
{
    public class PerformanceMessureFilter : IActionFilter
    {
        private Stopwatch _stopWatch;

        public void OnActionExecuting( ActionExecutingContext filterContext )
        {
            _stopWatch = Stopwatch.StartNew( );
        }

        public void OnActionExecuted( ActionExecutedContext filterContext )
        {
            _stopWatch.Stop( );

            filterContext.Controller.ViewData[ "Elapsed" ] = _stopWatch.ElapsedTicks;
        }
    }
}