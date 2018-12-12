using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeoPoc.Web.Startup))]
namespace SeoPoc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
