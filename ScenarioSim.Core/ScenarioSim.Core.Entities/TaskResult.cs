using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This class represents the results from a performance of a given task.
    /// </summary>
    public class TaskResult
    {
        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task that was performed.
        /// </value>
        public Task Task { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The accuracy metric results for the task.
        /// </summary>
        public List<AccuracyMetricResult> Results { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user that performed this task.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the elapsed time.
        /// </summary>
        /// <value>
        /// The elapsed time to complete the task.
        /// </value>
        public long ElapsedTime { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        protected TaskResult()
        {
            Results = new List<AccuracyMetricResult>();
        }

        /// <summary>
        /// Gets the tree node.
        /// </summary>
        /// <returns></returns>
        public virtual TreeNode<TaskResult> GetTreeNode()
        {
            return new TreeNode<TaskResult>(this);
        }
    }
}
