using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScenarioSim.PerformanceAnalysisWeb.Startup))]
namespace ScenarioSim.PerformanceAnalysisWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
