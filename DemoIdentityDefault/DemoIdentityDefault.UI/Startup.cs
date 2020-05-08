using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoIdentityDefault.UI.Startup))]
namespace DemoIdentityDefault.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
