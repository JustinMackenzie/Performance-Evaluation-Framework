using System;
using BuildingBlocks.EventBus.Events;

namespace SchemaManagement.API.Events.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.Event" />
    public class TaskCreatedEvent : Event
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
        /// Initializes a new instance of the <see cref="TaskCreatedEvent"/> class.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="name">The name.</param>
        public TaskCreatedEvent(Guid schemaId, string name)
        {
            this.SchemaId = schemaId;
            this.Name = name;
        }
    }
}
