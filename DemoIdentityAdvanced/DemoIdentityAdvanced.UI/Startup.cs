using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(DemoIdentityAdvanced.UI.Startup))]
namespace DemoIdentityAdvanced.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
