using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a task that composed of subtasks that are executed at the same time.
    /// </summary>
    public class ParallelTask : Task
    {
        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
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
