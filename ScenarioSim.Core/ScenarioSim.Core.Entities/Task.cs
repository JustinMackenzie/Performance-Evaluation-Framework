using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// The task class represents a task that is to be performed by an actor in 
    /// a scenario.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        /// The collection of accuracy metrics to be evaluated during simulation.
        /// </summary>
        public List<AccuracyMetric> AccuracyMetrics { get; set; }

        /// <summary>
        /// Default contructor that initializes the task.
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
        /// Sets the specific values.
        /// </summary>
        /// <param name="specificTask">The specific task.</param>
        public virtual void SetSpecificValues(Task specificTask)
        {
            Name = specificTask.Name;
        }
    }
}
