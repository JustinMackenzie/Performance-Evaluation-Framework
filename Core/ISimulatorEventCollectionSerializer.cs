using System;
namespace ScenarioSim.Core
{
    public interface ISimulatorEventCollectionSerializer
    {
        void Serialize(string filename, SimulatorEventCollection collection);
        SimulatorEventCollection Deserialize(string filename);
    }
}
