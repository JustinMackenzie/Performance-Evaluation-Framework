using Ninject;
using Ninject.Modules;
using ScenarioSim.Playback;
using ScenarioSim.Services.Playback;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.DependencyResolution
{
    public class PlaybackModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IScenarioPlayback>().To<ScenarioPlayback>()
                .WithConstructorArgument("simulator", context => context.Kernel.Get<IScenarioSimulator>());
        }
    }
}
