using System;
using System.Collections.Generic;
using ScenarioSim.Utility;

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
        public virtual Task ParentTask { get; set; }

        /// <summary>
        /// Gets or sets the sub tasks.
        /// </summary>
        /// <value>
        /// The sub tasks.
        /// </value>
        public virtual ICollection<Task> Tasks { get; set; }

        /// <summary>
        /// Gets the task tree node.
        /// </summary>
        /// <returns>
        /// A task tree node based on this task.
        /// </returns>
        public TreeNode<Task> GetTaskTreeNode()
        {
            TreeNode<Task> node = new TreeNode<Task>(this);

            foreach (Task subTask in Tasks)
                node.AppendChild(subTask.GetTaskTreeNode());

            return node;
        }
    }
}
