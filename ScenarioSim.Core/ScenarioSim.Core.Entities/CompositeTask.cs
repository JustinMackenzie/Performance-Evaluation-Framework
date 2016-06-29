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
        public List<Task> Tasks { get; set; }

        /// <summary>
        /// Gets the task tree node.
        /// </summary>
        /// <returns>
        /// A task tree node based on this task.
        /// </returns>
        public override TreeNode<Task> GetTaskTreeNode()
        {
            TreeNode<Task> node = new TreeNode<Task>(this);

            foreach (Task subTask in Tasks)
                node.AppendChild(subTask.GetTaskTreeNode());

            return node;
        }
    }
}
