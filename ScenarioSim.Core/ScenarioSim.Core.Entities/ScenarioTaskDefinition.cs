using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the scenario specific task definition.
    /// </summary>
    public class ScenarioTaskDefinition
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the task values.
        /// </summary>
        /// <value>
        /// The task values.
        /// </value>
        public TaskValues TaskValues { get; set; }
    }
}