using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This class represents the results from a performance of a given task.
    /// </summary>
    public class TaskPerformance : Entity
    {
        /// <summary>
        /// Gets or sets the scenario performance identifier.
        /// </summary>
        /// <value>
        /// The scenario performance identifier.
        /// </value>
        public Guid ScenarioPerformanceId { get; set; }

        /// <summary>
        /// Gets or sets the scenario performance.
        /// </summary>
        /// <value>
        /// The scenario performance.
        /// </value>
        public virtual ScenarioPerformance ScenarioPerformance { get; set; }

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
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the task performance values identifier.
        /// </summary>
        /// <value>
        /// The task performance values identifier.
        /// </value>
        public Guid TaskPerformanceValuesId { get; set; }

        /// <summary>
        /// Gets or sets the task performance values.
        /// </summary>
        /// <value>
        /// The task performance values.
        /// </value>
        public virtual TaskPerformanceValues TaskPerformanceValues { get; set; }
    }
}
