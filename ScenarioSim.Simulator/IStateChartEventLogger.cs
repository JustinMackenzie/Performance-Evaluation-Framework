using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    interface IStateChartEventLogger
    {
        void Log(IStateChartEvent e);
    }
}
