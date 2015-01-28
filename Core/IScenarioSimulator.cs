using System;
namespace ScenarioSim.Core
{
    public interface IScenarioSimulator
    {
        void AddTrackedParameter(int eventId, string parameterName);
        void Start();
        void SubmitSimulatorEvent(SimulatorEvent e);
    }
}
