using System;
using BuildingBlocks.EventBus.Events;

namespace SchemaManagement.API.Events.Events
{
    public class SchemaCreatedEvent : Event
    {
        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; private set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaCreatedEvent"/> class.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public SchemaCreatedEvent(Guid schemaId, string name, string description)
        {
            this.SchemaId = schemaId;
            this.Name = name;
            this.Description = description;
        }
    }
}
