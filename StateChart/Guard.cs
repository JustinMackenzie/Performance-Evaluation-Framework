using System;

namespace ScenarioSim.StateChart
{
    public interface Guard
    {
        Boolean Check(StateDataContainer dataContainer);
    }
}

