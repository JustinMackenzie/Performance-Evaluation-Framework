
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
    }
}
