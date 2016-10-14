using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.DataTransfer
{
    /// <summary>
    /// Represents a performance of a scenario.
    /// </summary>
    public class Performance
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the performer identifier.
        /// </summary>
        /// <value>
        /// The performer identifier.
        /// </value>
        public Guid PerformerId { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Gets or sets the task performances.
        /// </summary>
        /// <value>
        /// The task performances.
        /// </value>
        public Dictionary<Guid, TaskPerformance> TaskPerformances { get; set; }

        /// <summary>
        /// Gets or sets the user actions.
        /// </summary>
        /// <value>
        /// The user actions.
        /// </value>
        public List<PerformanceEvent> Events { get; set; }
    }
}