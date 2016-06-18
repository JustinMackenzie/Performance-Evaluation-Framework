using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// The task class represents a task that is to be performed by an actor in 
    /// a scenario.
    /// </summary>
    public class Task : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        /// <value>
        /// The actor responsible for completing this task.
        /// </value>
        public Actor Actor { get; set; }

        /// <summary>
        /// Determines whether this is the final task of the scenario.
        /// </summary>
        public bool Final { get; set; }

        /// <summary>
        /// Determines whether this task will be evaluated for accuracy.
        /// </summary>
        public bool EvaluateValue { get; set; }

        /// <summary>
        /// Gets or sets the accuracy metrics.
        /// </summary>
        /// <value>
        /// The accuracy metrics.
        /// </value>
        public List<AccuracyMetric> AccuracyMetrics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        public Task()
        {
            AccuracyMetrics = new List<AccuracyMetric>();
        }

        /// <summary>
        /// Gets the task tree node.
        /// </summary>
        /// <returns>A task tree node based on this task.</returns>
        public virtual TreeNode<Task> GetTaskTreeNode()
        {
            return new TreeNode<Task>(this);
        }

        /// <summary>
        /// Gets or sets the task values.
        /// </summary>
        /// <value>
        /// The task values.
        /// </value>
        public TaskValues TaskValues { get; set; }
    }
}
