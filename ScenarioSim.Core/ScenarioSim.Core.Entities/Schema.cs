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
        /// The task to be performed in this scenario.
        /// </summary>
        public Task Task { get; set; }

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
