using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI.Orion.Startup))]
namespace UI.Orion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
