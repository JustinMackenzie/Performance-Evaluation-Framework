using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    public interface IStateChartReader
    {
        IStateChartEngine Read(string fileName);
    }
}
