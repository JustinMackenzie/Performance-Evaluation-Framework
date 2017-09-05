using System;
using MediatR;
using SchemaManagement.Domain;

namespace Gateway.API.Command.SchemaManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest" />
    public class CreateTaskTransitionCommand : IRequest<TaskTransition>
    {
        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; set; }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the name of the source task.
        /// </summary>
        /// <value>
        /// The name of the source task.
        /// </value>
        public string SourceTaskName { get; set; }

        /// <summary>
        /// Gets or sets the name of the destination task.
        /// </summary>
        /// <value>
        /// The name of the destination task.
        /// </value>
        public string DestinationTaskName { get; set; }
    }
}
