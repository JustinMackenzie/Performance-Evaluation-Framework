namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the performance result of a fitts task.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskResult" />
    public class FittsTaskResult : TaskResult
    {
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time to complete the task.
        /// </value>
        public float Time => 1.0f * ElapsedTime / 1000;
    }
}