using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HtmlMinifyExample.Startup))]
namespace HtmlMinifyExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
