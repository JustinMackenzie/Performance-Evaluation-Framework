using System;

namespace ScenarioSim.StateChart
{
    public interface IAction
    {
        void Execute(StateDataContainer container);
    }
}


