using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScenarioSim.WebApp.Startup))]
namespace ScenarioSim.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
