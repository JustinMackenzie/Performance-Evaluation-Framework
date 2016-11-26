namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the values of a task performance.
    /// </summary>
    public class TaskPerformanceValues : Entity
    {
        /// <summary>
        /// Gets or sets the elapsed time.
        /// </summary>
        /// <value>
        /// The elapsed time to complete the task in milliseconds.
        /// </value>
        public long ElapsedTime { get; set; }
    }
}