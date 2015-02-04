
namespace ScenarioSim.Core
{
    /// <summary>
    /// Represents a complication that is triggered when a task is started or finished.
    /// </summary>
    public class TaskDependantComplication : Complication
    {
        /// <summary>
        /// The task that the complication depends on.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Determines if the complication is triggered at the start of a task. 
        /// </summary>
        public bool Entry { get; set; }
    }
}
