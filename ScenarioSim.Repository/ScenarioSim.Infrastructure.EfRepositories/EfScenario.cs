using System;
using System.Collections.Generic;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// The view model for scenario details.
    /// </summary>
    public class EfScenario : EfEntity
    {
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
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public EfSchema Schema { get; set; }

        /// <summary>
        /// Gets or sets the task definitions.
        /// </summary>
        /// <value>
        /// The task definitions.
        /// </value>
        public List<EfTaskDefinition> ScenarioTaskDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public List<EfScenarioEvent> Events { get; set; }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<EfAsset> Assets { get; set; }
    }
}