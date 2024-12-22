using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTSL.BdArmy.Web.Startup))]
namespace PTSL.BdArmy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
