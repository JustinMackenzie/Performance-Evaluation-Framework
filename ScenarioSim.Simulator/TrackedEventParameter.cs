using System;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class TrackedEventParameter
    {
        public DateTime Timestamp { get; set; }
        public EventParameter Parameter { get; set; }
    }
}
