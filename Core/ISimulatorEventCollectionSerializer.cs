using System;
namespace ScenarioSim.Core
{
    interface ISimulatorEventCollectionSerializer
    {
        void Serialize(string filename, SimulatorEventCollection collection);
        SimulatorEventCollection Deserialize(string filename);
    }
}
