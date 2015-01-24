using System;
namespace ScenarioSim.Core
{
    interface ISimulatorEventHandler
    {
        void SubmitEvent(SimulatorEvent e);
    }
}
