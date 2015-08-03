using System.Collections.Generic;

namespace ScenarioSim.Simulator
{
    public class TrackedEventParameters
    {
        public List<EventParameterPair> Items { get; set; }

        public TrackedEventParameters()
        {
            Items = new List<EventParameterPair>();
        }
    }

    public struct EventParameterPair
    {
        public int EventId { get; set; }
        public string ParameterName { get; set; }
    }
}
