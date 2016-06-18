using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TaskPerformance" />
    public class CompositeTaskPerformance : TaskPerformance
    {
        /// <summary>
        /// Gets or sets the task results.
        /// </summary>
        /// <value>
        /// The task results.
        /// </value>
        public IEnumerable<TaskPerformance> TaskResults { get; set; }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public float Time => 1.0f * TaskResults.Sum(r => r.TaskPerformanceValues.ElapsedTime) / 1000;

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
