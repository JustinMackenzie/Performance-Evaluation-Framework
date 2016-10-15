using System;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents the results of a performance of a task.
    /// </summary>
    public class EfTaskPerformance : EfEntity
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
        public virtual EfTask Task { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the task performance values elapsed time in milliseconds.
        /// </summary>
        /// <value>
        /// The task performance values elapsed time.
        /// </value>
        public long TaskPerformanceValuesElapsedTime { get; set; }
    }
}