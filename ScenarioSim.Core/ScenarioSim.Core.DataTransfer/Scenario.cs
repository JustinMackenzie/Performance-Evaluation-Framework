using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.DataTransfer
{
    /// <summary>
    /// The view model for scenario details.
    /// </summary>
    public class Scenario
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
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; set; }

        /// <summary>
        /// Gets or sets the task definitions.
        /// </summary>
        /// <value>
        /// The task definitions.
        /// </value>
        public List<TaskDefinition> ScenarioTaskDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public List<ScenarioEvent> Events { get; set; }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<Asset> Assets { get; set; }
    }
}