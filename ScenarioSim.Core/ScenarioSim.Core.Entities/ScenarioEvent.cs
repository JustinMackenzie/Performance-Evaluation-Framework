using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents an event that occurs during a scenario performance.
    /// </summary>
    public class ScenarioEvent
    {
        /// <summary>
        /// The name of the events.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The unique identifier of the event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The time in which the event occurred.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The collection of parameters for this event.
        /// </summary>
        public EventParameterCollection Parameters { get; set; }
    }
}
