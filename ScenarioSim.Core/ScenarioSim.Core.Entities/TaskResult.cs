using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This class represents the results from a performance of a given task.
    /// </summary>
    public class TaskResult
    {
        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task that was performed.
        /// </value>
        public Task Task { get; set; }

        /// <summary>
        /// The accuracy metric results for the task.
        /// </summary>
        public List<AccuracyMetricResult> Results { get; set; }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// The speed of completing the task in milliseconds.
        /// </value>
        public long Speed { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        protected TaskResult()
        {
            Results = new List<AccuracyMetricResult>();
        }
    }
}
