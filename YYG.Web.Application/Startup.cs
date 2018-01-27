using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YYG.Web.Application.Startup))]
namespace YYG.Web.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
