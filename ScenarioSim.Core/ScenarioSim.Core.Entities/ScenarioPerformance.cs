using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// The performance of a scenario performance.
    /// </summary>
    public class ScenarioPerformance : Entity
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// The scenario that was performed.
        /// </summary>
        public virtual Scenario Scenario { get; set; }

        /// <summary>
        /// Gets or sets the performer identifier.
        /// </summary>
        /// <value>
        /// The performer identifier.
        /// </value>
        public Guid PerformerId { get; set; }

        /// <summary>
        /// Gets or sets the performer.
        /// </summary>
        /// <value>
        /// The performer.
        /// </value>
        public virtual Performer Performer { get; set; }

        /// <summary>
        /// Gets or sets the task performances.
        /// </summary>
        /// <value>
        /// The task performances.
        /// </value>
        public Dictionary<Guid, TaskPerformance> TaskPerformances { get; set; }

        /// <summary>
        /// Gets the task performance tree.
        /// </summary>
        /// <value>
        /// The task performance tree.
        /// </value>
        public TreeNode<TaskPerformance> TaskPerformanceTree => BuildTaskPerfomanceTree(Scenario.TaskTree);

        /// <summary>
        /// Gets or sets the user actions.
        /// </summary>
        /// <value>
        /// The user actions.
        /// </value>
        public List<PerformerAction> UserActions { get; set; }

        /// <summary>
        /// Builds the task perfomance tree.
        /// </summary>
        /// <param name="taskTree">The task tree.</param>
        /// <returns></returns>
        private TreeNode<TaskPerformance> BuildTaskPerfomanceTree(TreeNode<Task> taskTree)
        {
            TreeNode<TaskPerformance> treeNode = new TreeNode<TaskPerformance>(TaskPerformances[taskTree.Value.Id]);

            foreach (TreeNode<Task> child in taskTree.Children)
                treeNode.AppendChild(TaskPerformances[child.Value.Id]);

            return treeNode;
        }
    }
}
