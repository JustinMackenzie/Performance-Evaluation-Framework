using System;
using ScenarioSim.Core;

namespace ScenarioSim.StateChart
{
    public class StateChartEvent : IStateChartEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StateChartEvent()
        {
            Name = string.Empty;
        }

        public StateChartEvent(int id)
        {
            Id = id;
            Name = string.Empty;
        }

        public StateChartEvent(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Boolean Equals(StateChartEvent stateChartEvent, StateDataContainer dataContainer)
        {
            return stateChartEvent != null ? Id.CompareTo(stateChartEvent.Id) == 0 : false;
        }
    }
}

