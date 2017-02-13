using System.Collections.Generic;
using ScenarioSim.Utility;

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
        /// Gets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public Task Task { get; set; }

        /// <summary>
        /// Gets the task transitions.
        /// </summary>
        /// <value>
        /// The task transitions.
        /// </value>
        public List<TaskTransition> TaskTransitions { get; set; }

        /// <summary>
        /// Gets the task tree.
        /// </summary>
        /// <value>
        /// The task tree.
        /// </value>
        public TreeNode<Task> TaskTree => Task.GetTaskTreeNode();

        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        /// <value>
        /// The actors.
        /// </value>
        public List<Actor> Actors { get; set; }
    }
}
