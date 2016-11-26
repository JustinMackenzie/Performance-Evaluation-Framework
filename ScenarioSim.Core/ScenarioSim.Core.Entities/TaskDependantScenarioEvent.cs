using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a complication that is triggered when a task is started or finished.
    /// </summary>
    public class TaskDependantScenarioEvent : ScenarioEvent
    {
        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual Task Task { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TaskDependantScenarioEvent"/> is entry.
        /// </summary>
        /// <value>
        ///   <c>true</c> if entry; otherwise, <c>false</c>.
        /// </value>
        public bool Entry { get; set; }
    }
}
