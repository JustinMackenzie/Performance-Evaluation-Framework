using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// An event that represents that a goal was completed.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.Event" />
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
