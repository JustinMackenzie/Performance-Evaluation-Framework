namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the performance result of a fitts task.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskResult" />
    public class FittsTaskResult : TaskResult
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time taken to complete the task.
        /// </value>
        public float Time { get; set; }
    }
}