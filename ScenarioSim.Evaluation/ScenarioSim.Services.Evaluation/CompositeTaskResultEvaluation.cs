using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of the composite task results.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.TaskResultEvaluation" />
    public class CompositeTaskResultEvaluation : TaskResultEvaluation
    {

        /// <summary>
        /// Gets or sets the task result evaluations.
        /// </summary>
        /// <value>
        /// The task result evaluations.
        /// </value>
        public IEnumerable<TaskResultEvaluation> TaskResultEvaluations { get; set; }

        /// <summary>
        /// Gets the tree node.
        /// </summary>
        /// <returns></returns>
        public override TreeNode<TaskResultEvaluation> GetTreeNode()
        {
            TreeNode<TaskResultEvaluation> treeNode = base.GetTreeNode();

            foreach (TaskResultEvaluation evaluation in TaskResultEvaluations)
                treeNode.AppendChild(evaluation.GetTreeNode());

            return treeNode;
        }
    }
}