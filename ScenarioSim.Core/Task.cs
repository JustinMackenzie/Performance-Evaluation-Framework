using System.Collections.Generic;

namespace ScenarioSim.Core
{
    /// <summary>
    /// The task class represents a task that is to be performed by an actor in 
    /// a scenario.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// The name of the task.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Determines whether this is the final task of the scenario.
        /// </summary>
        public bool Final { get; set; }

        /// <summary>
        /// Determines whether this task will be evaluated for accuracy.
        /// </summary>
        public bool EvaluateValue { get; set; }

        /// <summary>
        /// The collection of accuracy metrics to be evaluated during simulation.
        /// </summary>
        public List<AccuracyMetric> AccuracyMetrics { get; set; }

        /// <summary>
        /// Default contructor that initializes the task.
        /// </summary>
        public Task()
        {
            AccuracyMetrics = new List<AccuracyMetric>();
        }
    }
}
