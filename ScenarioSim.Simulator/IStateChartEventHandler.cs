using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    interface IStateChartEventHandler
    {
        void SubmitEvent(IStateChartEvent e);
    }
}
