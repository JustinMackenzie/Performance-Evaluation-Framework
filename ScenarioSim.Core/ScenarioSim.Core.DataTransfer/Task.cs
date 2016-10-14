using System;

namespace ScenarioSim.Core.DataTransfer
{
    /// <summary>
    /// Represents a task.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        /// <value>
        /// The type of the task.
        /// </value>
        public string TaskType { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
    }
}