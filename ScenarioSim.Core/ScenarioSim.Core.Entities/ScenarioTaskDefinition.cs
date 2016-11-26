using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the scenario specific task definition.
    /// </summary>
    public class ScenarioTaskDefinition : Entity
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the scenario.
        /// </summary>
        /// <value>
        /// The scenario.
        /// </value>
        public virtual Scenario Scenario { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual Task Task { get; set; }

        /// <summary>
        /// Gets or sets the task values identifier.
        /// </summary>
        /// <value>
        /// The task values identifier.
        /// </value>
        public Guid TaskValuesId { get; set; }

        /// <summary>
        /// Gets or sets the task values.
        /// </summary>
        /// <value>
        /// The task values.
        /// </value>
        public virtual TaskValues TaskValues { get; set; }
    }
}