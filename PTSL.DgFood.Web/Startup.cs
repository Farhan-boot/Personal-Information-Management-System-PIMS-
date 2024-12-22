using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTSL.DgFood.Web.Startup))]
namespace PTSL.DgFood.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
