using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a task that is composed of child tasks.
    /// </summary>
    public class CompositeTask : Task
    {
        /// <summary>
        /// Gets or sets the sub tasks.
        /// </summary>
        /// <value>
        /// The sub tasks.
        /// </value>
        public IEnumerable<Task> SubTasks { get; set; } 
    }
}
