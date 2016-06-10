using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.FittsEvaluator
{
    /// <summary>
    /// Represents a pair of the fitts task and the performance result of that task.
    /// </summary>
    internal struct FittsTaskResultPair
    {
        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public FittsTask Task { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public FittsTaskResult Result { get; set; }
    }
}