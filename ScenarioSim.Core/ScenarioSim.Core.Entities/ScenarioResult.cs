using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// The result of a scenario performance.
    /// </summary>
    public class ScenarioResult
    {
        /// <summary>
        /// The user that performed the scenario.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The path to the scenario file.
        /// </summary>
        public string ScenarioFile { get; set; }

        /// <summary>
        /// The performance results of the tasks.
        /// </summary>
        public TreeNode<TaskResult> TaskResult { get; set; }

        /// <summary>
        /// The collection of scenario events that were submitted.
        /// </summary>
        public List<ScenarioEvent> Events { get; set; }

        /// <summary>
        /// A collection of the tracked parameters from the performance.
        /// </summary>
        public List<TrackedEventParameter> TrackedParameters { get; set; }

        /// <summary>
        /// The scenario that was performed.
        /// </summary>
        public Scenario Scenario { get; set; }
    }
}
