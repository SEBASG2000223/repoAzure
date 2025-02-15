using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlDeRiesgoFinanciero.UI.Startup))]
namespace ControlDeRiesgoFinanciero.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
