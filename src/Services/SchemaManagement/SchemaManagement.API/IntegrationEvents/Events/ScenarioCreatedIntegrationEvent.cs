using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Events;

namespace SchemaManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ScenarioCreatedIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; private set; }

        /// <summary>
        /// Gets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioCreatedIntegrationEvent"/> class.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="name">The name.</param>
        public ScenarioCreatedIntegrationEvent(Guid scenarioId, Guid schemaId, string name)
        {
            this.ScenarioId = scenarioId;
            this.SchemaId = schemaId;
            this.Name = name;
        }

    }
}
