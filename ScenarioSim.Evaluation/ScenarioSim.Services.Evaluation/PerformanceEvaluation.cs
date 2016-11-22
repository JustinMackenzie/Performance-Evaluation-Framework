using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of a collection scenario performances.
    /// </summary>
    public class PerformanceEvaluation
    {
        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets the scenario results.
        /// </summary>
        /// <value>
        /// The scenario results.
        /// </value>
        public IEnumerable<ScenarioPerformance> ScenarioResults { get; set; }

        /// <summary>
        /// Gets or sets the task performance evaluations.
        /// </summary>
        /// <value>
        /// The task performance evaluations.
        /// </value>
        public Dictionary<Guid, TaskPerformanceEvaluation> TaskPerformanceEvaluations { get; set; }

        /// <summary>
        /// Gets the task performance evaluation tree.
        /// </summary>
        /// <value>
        /// The task performance evaluation tree.
        /// </value>
        public TreeNode<TaskPerformanceEvaluation> TaskPerformanceEvaluationTree => BuildTaskPerformanceEvaluationTree(Schema.TaskTree);

        private TreeNode<TaskPerformanceEvaluation> BuildTaskPerformanceEvaluationTree(TreeNode<Task> taskTreeNode)
        {
            TreeNode<TaskPerformanceEvaluation> node = new TreeNode<TaskPerformanceEvaluation>(TaskPerformanceEvaluations[taskTreeNode.Value.Id]);

            foreach (TreeNode<Task> child in taskTreeNode.Children)
                node.AppendChild(TaskPerformanceEvaluations[child.Value.Id]);

            return node;
        }
    }
}