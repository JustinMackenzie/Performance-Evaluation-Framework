using Ninject;
using Ninject.Modules;
using ScenarioSim.Infrastructure.Simulator;
using ScenarioSim.Infrastructure.UmlStateChart;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.DependencyResolution
{
    public class SimulatorModule : NinjectModule
    {
        private IEntityPlacer placer;

        public SimulatorModule(IEntityPlacer placer)
        {
            this.placer = placer;
        }

        public override void Load()
        {
            Bind<IScenarioSimulator>().
                To<ScenarioSimulator>()
                .WithConstructorArgument("placer", placer)
                .WithConstructorArgument("enactorRepository",
                    context => context.Kernel.Get<IComplicationEnactorRepository>())
                .WithConstructorArgument("componentRepository",
                    context => context.Kernel.Get<ISimulationComponentRepository>());

            Bind<ISimulationComponentRepository>().To<SimulationComponentRepository>();
            Bind<IComplicationEnactorRepository>().To<ComplicationEnactorRepository>().InSingletonScope();
            Bind<IStateChartBuilder>()
                .To<UmlStateChartBuilder>();
        }
    }
}
