using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SHEMO.Startup))]
namespace SHEMO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
