using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core.Entities
{
    public class ParallelTaskResult : TaskResult
    {
        /// <summary>
        /// Gets or sets the task results.
        /// </summary>
        /// <value>
        /// The task results.
        /// </value>
        public IEnumerable<TaskResult> TaskResults { get; set; }

        /// <summary>
        /// Gets the tree node.
        /// </summary>
        /// <returns></returns>
        public override TreeNode<TaskResult> GetTreeNode()
        {
            TreeNode<TaskResult> node = new TreeNode<TaskResult>(this);

            foreach (TaskResult taskResult in TaskResults)
                node.AppendChild(taskResult);

            return node;
        }
    }
}
