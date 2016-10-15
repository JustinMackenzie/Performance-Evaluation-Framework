using System;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents a task.
    /// </summary>
    public class EfTask : EfEntity
    {
        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        /// <value>
        /// The type of the task.
        /// </value>
        public string TaskType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent task identifier.
        /// </summary>
        /// <value>
        /// The parent task identifier.
        /// </value>
        public Guid? ParentTaskId { get; set; }

        /// <summary>
        /// Gets or sets the parent task.
        /// </summary>
        /// <value>
        /// The parent task.
        /// </value>
        public EfTask ParentTask { get; set; }
    }
}