using System;

namespace UmlStateChart
{
    public class StateChartEvent
    {
        public int Id { get; set; }

        public StateChartEvent()
        {

        }

        public StateChartEvent(int id)
        {
            Id = id;
        }

        public Boolean Equals(StateChartEvent stateChartEvent, StateDataContainer dataContainer)
        {
            return stateChartEvent != null ? Id.CompareTo(stateChartEvent.Id) == 0 : false;
        }
    }
}

