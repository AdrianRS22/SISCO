using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SISCO.Web.Startup))]
namespace SISCO.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
