using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents a pair of the fitts task and the performance result of that task.
    /// </summary>
    public struct FittsTaskResultPair
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