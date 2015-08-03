using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public interface ISimulationComponent
    {
        void Start();
        void SubmitEvent(ScenarioEvent e);
        void Complete();
    }
}
