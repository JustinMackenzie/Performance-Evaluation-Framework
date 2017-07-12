using System.Collections.Generic;
using Schema.Domain.SeedWork;

namespace Schema.Domain
{
    /// <summary>
    /// Represents the transition from one task to another.
    /// </summary>
    /// <seealso cref="Schema.Domain.ValueObject" />
    public class TaskTransition : ValueObject
    {
        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        public string EventName { get; private set; }

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
        /// Initializes a new instance of the <see cref="TaskTransition"/> class.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="sourceTaskName">Name of the source task.</param>
        /// <param name="destinationTaskName">Name of the destination task.</param>
        public TaskTransition(string eventName, string sourceTaskName, string destinationTaskName)
        {
            this.EventName = eventName;
            this.SourceTaskName = sourceTaskName;
            this.DestinationTaskName = destinationTaskName;
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.EventName;
            yield return this.SourceTaskName;
            yield return this.DestinationTaskName;
        }
    }
}