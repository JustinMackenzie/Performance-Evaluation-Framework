using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This class represents the results from a performance of a given task.
    /// </summary>
    public class TaskPerformance : Entity
    {
        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task that was performed.
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
        /// The accuracy metric results for the task.
        /// </summary>
        public List<AccuracyMetricResult> Results { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user that performed this task.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the task performance values.
        /// </summary>
        /// <value>
        /// The task performance values.
        /// </value>
        public TaskPerformanceValues TaskPerformanceValues { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        protected TaskPerformance()
        {
            Results = new List<AccuracyMetricResult>();
        }
    }
}
