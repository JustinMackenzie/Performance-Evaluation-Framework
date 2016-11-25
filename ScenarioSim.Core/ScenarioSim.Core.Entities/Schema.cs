using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a plan or abstract scenario.
    /// </summary>
    public class Schema : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the scenarios.
        /// </summary>
        /// <value>
        /// The scenarios.
        /// </value>
        public virtual ICollection<Scenario> Scenarios { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public int TaskId { get; set; }

        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual Task Task { get; set; }

        /// <summary>
        /// Gets the task transitions.
        /// </summary>
        /// <value>
        /// The task transitions.
        /// </value>
        public virtual ICollection<TaskTransition> TaskTransitions { get; set; }

        /// <summary>
        /// Gets the task tree.
        /// </summary>
        /// <value>
        /// The task tree.
        /// </value>
        public TreeNode<Task> TaskTree => Task.GetTaskTreeNode();
    }
}
