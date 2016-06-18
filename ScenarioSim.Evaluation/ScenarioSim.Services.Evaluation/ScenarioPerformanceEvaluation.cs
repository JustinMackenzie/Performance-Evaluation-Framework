using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of a collection scenario performances.
    /// </summary>
    public class ScenarioPerformanceEvaluation
    {
        /// <summary>
        /// Gets or sets the scenario results.
        /// </summary>
        /// <value>
        /// The scenario results.
        /// </value>
        public IEnumerable<ScenarioPerformance> ScenarioResults { get; set; }

        /// <summary>
        /// Gets or sets the task result evaluation.
        /// </summary>
        /// <value>
        /// The task result evaluation.
        /// </value>
        public TaskPerformanceEvaluation TaskPerformanceEvaluation { get; set; }

        /// <summary>
        /// Gets the task performance evaluation tree.
        /// </summary>
        /// <value>
        /// The task performance evaluation tree.
        /// </value>
        public TreeNode<TaskPerformanceEvaluation> TaskPerformanceEvaluationTree => TaskPerformanceEvaluation.GetTreeNode();
    }
}