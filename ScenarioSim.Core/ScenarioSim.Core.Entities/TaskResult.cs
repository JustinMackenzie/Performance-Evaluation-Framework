using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This class represents the results from a performance of a given task.
    /// </summary>
    public class TaskResult
    {
        /// <summary>
        /// The name of the task.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// The accuracy metric results for the task.
        /// </summary>
        public List<AccuracyMetricResult> Results { get; set; }

        /// <summary>
        /// The speed of the task.
        /// </summary>
        public long Speed { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public TaskResult()
        {
            Results = new List<AccuracyMetricResult>();
        }
    }
}
