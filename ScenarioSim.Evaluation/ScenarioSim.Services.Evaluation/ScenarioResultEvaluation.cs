using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of a collection scenario results.
    /// </summary>
    public class ScenarioResultEvaluation
    {
        /// <summary>
        /// Gets or sets the scenario results.
        /// </summary>
        /// <value>
        /// The scenario results.
        /// </value>
        public IEnumerable<ScenarioResult> ScenarioResults { get; set; }

        /// <summary>
        /// Gets or sets the task result evaluation.
        /// </summary>
        /// <value>
        /// The task result evaluation.
        /// </value>
        public TaskResultEvaluation TaskResultEvaluation { get; set; }

        /// <summary>
        /// Gets the task result evaluation tree.
        /// </summary>
        /// <value>
        /// The task result evaluation tree.
        /// </value>
        public TreeNode<TaskResultEvaluation> TaskResultEvaluationTree => TaskResultEvaluation.GetTreeNode();
    }
}