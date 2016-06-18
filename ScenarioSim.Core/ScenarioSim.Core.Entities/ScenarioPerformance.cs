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
        /// The scenario that was performed.
        /// </summary>
        public Scenario Scenario { get; set; }

        /// <summary>
        /// The user that performed the scenario.
        /// </summary>
        public User User { get; set; }

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
        /// The collection of user actions that were submitted.
        /// </summary>
        public List<UserAction> UserActions { get; set; }

        /// <summary>
        /// A collection of the tracked parameters from the performance.
        /// </summary>
        public List<TrackedEventParameter> TrackedParameters { get; set; }

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
