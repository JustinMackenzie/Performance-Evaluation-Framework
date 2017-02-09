using System;

namespace ScenarioSim.Performance.Entities
{
    /// <summary>
    /// An event that represents that a goal was completed.
    /// </summary>
    /// <seealso cref="Event" />
    public class GoalCompletedEvent : Event
    {
        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier of the task that is completed.
        /// </value>
        public Guid TaskId { get; set; }
    }
}
