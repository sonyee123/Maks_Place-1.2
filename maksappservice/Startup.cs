using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(maksappservice.Startup))]

namespace maksappservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}