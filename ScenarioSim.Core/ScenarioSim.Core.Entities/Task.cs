using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// The task class represents a task that is to be performed by an actor in 
    /// a scenario.
    /// </summary>
    public class Task : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the actor identifier.
        /// </summary>
        /// <value>
        /// The actor identifier.
        /// </value>
        public Guid ActorId { get; set; }

        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        /// <value>
        /// The actor responsible for completing this task.
        /// </value>
        public Actor Actor { get; set; }

        /// <summary>
        /// Gets or sets the task values.
        /// </summary>
        /// <value>
        /// The task values.
        /// </value>
        public TaskValues TaskValues { get; set; }

        /// <summary>
        /// Gets the task tree node.
        /// </summary>
        /// <returns>A task tree node based on this task.</returns>
        public virtual TreeNode<Task> GetTaskTreeNode()
        {
            return new TreeNode<Task>(this);
        }
    }
}
