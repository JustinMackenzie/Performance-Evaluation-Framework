using System;
using System.Collections.Generic;

namespace ScenarioSim.Simulator
{
    public interface ISimulationComponentRepository
    {
        void AddComponent(ISimulationComponent component);
        ISimulationComponent GetComponent(Type type);
        IEnumerable<ISimulationComponent> GetAllComponents();
    }
}
