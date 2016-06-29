using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This class represents the results from a performance of a given task.
    /// </summary>
    public class TaskPerformance
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
        public Task Task { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user that performed this task.
        /// </value>
        public Performer Performer { get; set; }

        /// <summary>
        /// Gets or sets the task performance values.
        /// </summary>
        /// <value>
        /// The task performance values.
        /// </value>
        public TaskPerformanceValues TaskPerformanceValues { get; set; }
    }
}
