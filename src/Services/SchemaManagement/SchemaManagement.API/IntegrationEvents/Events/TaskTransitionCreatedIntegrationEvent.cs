using System;
using BuildingBlocks.EventBus.Events;

namespace SchemaManagement.API.Events.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.Event" />
    public class TaskTransitionCreatedEvent : Event
    {
        /// <summary>
        /// Gets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; private set; }

        /// <summary>
        /// Gets the name of the source task.
        /// </summary>
        /// <value>
        /// The name of the source task.
        /// </value>
        public string SourceTaskName { get; private set; }

        /// <summary>
        /// Gets the name of the destination task.
        /// </summary>
        /// <value>
        /// The name of the destination task.
        /// </value>
        public string DestinationTaskName { get; private set; }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        public string EventName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskTransitionCreatedEvent" /> class.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="sourceTaskName">Name of the source task.</param>
        /// <param name="destinationTaskName">Name of the destination task.</param>
        /// <param name="eventName">Name of the event.</param>
        public TaskTransitionCreatedEvent(Guid schemaId, string sourceTaskName, string destinationTaskName,
            string eventName)
        {
            this.SchemaId = schemaId;
            this.SourceTaskName = sourceTaskName;
            this.DestinationTaskName = destinationTaskName;
            this.EventName = eventName;
        }

    }
}
