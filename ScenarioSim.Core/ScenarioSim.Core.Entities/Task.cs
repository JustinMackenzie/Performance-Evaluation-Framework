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
        /// Gets or sets the sub tasks.
        /// </summary>
        /// <value>
        /// The sub tasks.
        /// </value>
        public List<Task> SubTasks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        public Task()
        {
            SubTasks = new List<Task>();
        }

        /// <summary>
        /// Gets the task tree node.
        /// </summary>
        /// <returns>
        /// A task tree node based on this task.
        /// </returns>
        public TreeNode<Task> GetTaskTreeNode()
        {
            TreeNode<Task> node = new TreeNode<Task>(this);

            foreach (Task subTask in SubTasks)
                node.AppendChild(subTask.GetTaskTreeNode());

            return node;
        }
    }
}
