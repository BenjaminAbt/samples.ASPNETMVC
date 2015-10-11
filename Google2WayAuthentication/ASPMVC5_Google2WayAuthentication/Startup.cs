using Microsoft.Owin;
using Owin;

[assembly: OwinStartup( typeof( SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Startup ) )]
namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication
{
    public partial class Startup
    {
        public void Configuration( IAppBuilder app )
        {
            ConfigureAuth( app );
        }
    }
}
