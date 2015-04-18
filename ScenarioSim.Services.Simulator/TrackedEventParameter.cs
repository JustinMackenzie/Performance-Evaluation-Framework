using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// Represents a parameter at a specific instance in time.
    /// </summary>
    public class TrackedEventParameter
    {
        /// <summary>
        /// The time when this parameter was collected.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The parameter that is collected.
        /// </summary>
        public EventParameter Parameter { get; set; }
    }
}
