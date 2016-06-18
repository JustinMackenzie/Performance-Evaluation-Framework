using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of the composite task results.
    /// </summary>
    /// <seealso cref="TaskPerformanceEvaluation" />
    public class CompositeTaskPerformanceEvaluation : TaskPerformanceEvaluation
    {

        /// <summary>
        /// Gets or sets the task result evaluations.
        /// </summary>
        /// <value>
        /// The task result evaluations.
        /// </value>
        public IEnumerable<TaskPerformanceEvaluation> TaskResultEvaluations { get; set; }

        /// <summary>
        /// Gets the tree node.
        /// </summary>
        /// <returns></returns>
        public override TreeNode<TaskPerformanceEvaluation> GetTreeNode()
        {
            TreeNode<TaskPerformanceEvaluation> treeNode = base.GetTreeNode();

            foreach (TaskPerformanceEvaluation evaluation in TaskResultEvaluations)
                treeNode.AppendChild(evaluation.GetTreeNode());

            return treeNode;
        }
    }
}