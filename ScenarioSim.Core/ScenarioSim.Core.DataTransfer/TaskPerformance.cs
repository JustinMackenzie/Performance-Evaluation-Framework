using System;

namespace ScenarioSim.Core.DataTransfer
{
    /// <summary>
    /// Represents the results of a performance of a task.
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
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the task performance values elapsed time in milliseconds.
        /// </summary>
        /// <value>
        /// The task performance values elapsed time.
        /// </value>
        public long TaskPerformanceValuesElapsedTime { get; set; }
    }
}