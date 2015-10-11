﻿// TT File to generate RouteNames by XML Definition
// Original by Daniel Kailer 
// Extended and published by Benjamin Abt / www.schwabencode.com - www.benjamin-abt.com
// 
// For further updates please do not edit this file!
// Use the Routes.xml (or same name like this tt-file) do configurate your settings.

// <!-- CHECK THIS PATH ON ERROR -->

// Please do not edit 
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using SchwabenCode.Web.Mvc.Routing;

// Routes
namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Routing
{
    public static class GeneratedRoutesRegistration
    {
        /// <summary>
        /// Call this method on application start.
        /// </summary>
        public static void Register(RouteCollection routeCollection)
        {
	RouteExtensions.MapRouteEx(routeCollection, SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Routing.RouteNames.Home, "", new { Controller="Home", Action="Index"}, null, new [] { "SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Controllers" }, forceTrailingSlash: false);

        }
    }
}
// End Routes

// AccountArea
namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account
{
    public partial class AccountAreaRegistration
    {		
        public override void RegisterArea(AreaRegistrationContext context)
        {
            BeforeRegisterArea(context);

			RouteExtensions.MapRouteEx(context, SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Routing.RouteNames.AccountArea.Account_Login, "Account/Login", new { Controller="Account", Action="Login"}, null,new [] { "SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Controllers" }, "Account", forceTrailingSlash: false);

			RouteExtensions.MapRouteEx(context, SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Routing.RouteNames.AccountArea.Account, "Account", new { Controller="Account", Action="Index"}, null,new [] { "SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Controllers" }, "Account", forceTrailingSlash: false);


            AfterRegisterArea(context);
        }
        
        // Implement the following partial methods in the other partial class definition if required
        partial void BeforeRegisterArea(AreaRegistrationContext context);
        partial void AfterRegisterArea(AreaRegistrationContext context);
    }
}
// End AccountArea


// Route Naming
namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Routing
{
    /// <summary>
    /// Container of RouteNames
    /// </summary>
    public static class RouteNames
    {
        /// <summary></summary>
        public const string Home = "Home";
            /// <summary>
            /// Routes of AccountArea
            /// </summary>
            public static class AccountArea
            {
                /// <summary>Account/Login</summary>
                public const string Account_Login = "Account_Login";
                /// <summary>Account</summary>
                public const string Account = "Account";
            }

     }
}
// Route Naming End