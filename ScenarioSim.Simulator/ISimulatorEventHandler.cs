using System;
namespace ScenarioSim.Core
{
    interface ISimulatorEventHandler
    {
        void SubmitEvent(ScenarioEvent e);
        void Save(string filename);
    }
}
