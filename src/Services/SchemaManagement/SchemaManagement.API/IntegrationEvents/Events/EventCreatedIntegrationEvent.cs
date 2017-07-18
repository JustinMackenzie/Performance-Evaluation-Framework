using System;
using BuildingBlocks.EventBus.Events;

namespace SchemaManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class EventCreatedIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventCreatedIntegrationEvent"/> class.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="name">The name.</param>
        public EventCreatedIntegrationEvent(Guid schemaId, string name)
        {
            this.SchemaId = schemaId;
            this.Name = name;
        }
    }
}
