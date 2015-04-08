using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public class TrackedEventParameter
    {
        public DateTime Timestamp { get; set; }
        public EventParameter Parameter { get; set; }
    }
}
