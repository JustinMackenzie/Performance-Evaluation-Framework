using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public interface ISimulationComponent
    {
        void Start();
        void SubmitEvent(ScenarioEvent e);
        void Complete();
    }
}
