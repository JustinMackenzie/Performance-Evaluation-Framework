using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of the task results.
    /// </summary>
    public class TaskResultEvaluation
    {
        /// <summary>
        /// Gets or sets the task results.
        /// </summary>
        /// <value>
        /// The task results.
        /// </value>
        public IEnumerable<TaskResult> TaskResults { get; set; }

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
        public virtual TreeNode<TaskResultEvaluation> GetTreeNode()
        {
            return new TreeNode<TaskResultEvaluation>(this);
        }
    }
}
