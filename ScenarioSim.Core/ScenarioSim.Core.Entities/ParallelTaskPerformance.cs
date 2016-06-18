using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core.Entities
{
    public class ParallelTaskPerformance : TaskPerformance
    {
        /// <summary>
        /// Gets or sets the task results.
        /// </summary>
        /// <value>
        /// The task results.
        /// </value>
        public IEnumerable<TaskPerformance> TaskResults { get; set; }

        /// <summary>
        /// Gets the tree node.
        /// </summary>
        /// <returns></returns>
        public override TreeNode<TaskPerformance> GetTreeNode()
        {
            TreeNode<TaskPerformance> node = new TreeNode<TaskPerformance>(this);

            foreach (TaskPerformance taskResult in TaskResults)
                node.AppendChild(taskResult);

            return node;
        }
    }
}
