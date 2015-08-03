using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public interface IStateChartBuilder
    {
        IStateChartEngine Build(Scenario scenario);
    }
}
