using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public interface IStateChartBuilder
    {
        IStateChartEngine Build(Scenario scenario);
    }
}
