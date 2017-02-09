using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Performance.Entities
{
    /// <summary>
    /// The performance of a scenario performance.
    /// </summary>
    public class ScenarioPerformance : Entity
    {
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTimeOffset EndTime { get; set; }

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
        public Dictionary<Guid, TaskPerformance> TaskPerformances
            => TaskPerformanceCollection.ToDictionary(t => t.TaskId);

        /// <summary>
        /// Gets or sets the task performance collection.
        /// </summary>
        /// <value>
        /// The task performance collection.
        /// </value>
        public virtual ICollection<TaskPerformance> TaskPerformanceCollection { get; set; }

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
        public virtual ICollection<Event> Events { get; set; }

        /// <summary>
        /// Builds the task perfomance tree.
        /// </summary>
        /// <param name="taskTree">The task tree.</param>
        /// <returns></returns>
        private TreeNode<TaskPerformance> BuildTaskPerfomanceTree(TreeNode<Task> taskTree)
        {
            TaskPerformance performance = TaskPerformances.ContainsKey(taskTree.Value.Id)
                ? TaskPerformances[taskTree.Value.Id]
                : null;

            TreeNode<TaskPerformance> treeNode = new TreeNode<TaskPerformance>(performance);

            foreach (TreeNode<Task> child in taskTree.Children)
                treeNode.AppendChild(BuildTaskPerfomanceTree(child));

            return treeNode;
        }
    }
}
