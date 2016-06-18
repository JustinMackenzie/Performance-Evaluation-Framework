using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of the task results.
    /// </summary>
    public class TaskPerformanceEvaluation
    {
        /// <summary>
        /// Gets or sets the task performances.
        /// </summary>
        /// <value>
        /// The task performances.
        /// </value>
        public IEnumerable<TaskPerformance> TaskPerformances { get; set; }

        /// <summary>
        /// Gets or sets the task evaluation values.
        /// </summary>
        /// <value>
        /// The task evaluation values.
        /// </value>
        public TaskEvaluationValues TaskEvaluationValues { get; set; }

        /// <summary>
        /// Gets the tree node.
        /// </summary>
        /// <returns></returns>
        public virtual TreeNode<TaskPerformanceEvaluation> GetTreeNode()
        {
            return new TreeNode<TaskPerformanceEvaluation>(this);
        }
    }
}
