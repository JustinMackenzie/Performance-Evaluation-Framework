using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// A task transition represents a transition from one task to another
    /// in a flow chart. It contains the source task, destination task and the 
    /// identification of the event that triggers this transition in the state chart
    /// representation.
    /// </summary>
    public class TaskTransition : Entity
    {
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
        public virtual Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets the source identifier.
        /// </summary>
        /// <value>
        /// The source identifier.
        /// </value>
        public Guid SourceTaskId { get; set; }

        /// <summary>
        /// Gets or sets the source task.
        /// </summary>
        /// <value>
        /// The source task.
        /// </value>
        public virtual Task SourceTask { get; set; }

        /// <summary>
        /// Gets or sets the destination identifier.
        /// </summary>
        /// <value>
        /// The destination identifier.
        /// </value>
        public Guid DestinationTaskId { get; set; }

        /// <summary>
        /// Gets or sets the destination task.
        /// </summary>
        /// <value>
        /// The destination task.
        /// </value>
        public virtual Task DestinationTask { get; set; }

        /// <summary>
        /// Gets or sets the performer action identifier.
        /// </summary>
        /// <value>
        /// The performer action identifier.
        /// </value>
        public Guid PerformerActionId { get; set; }

        /// <summary>
        /// Gets or sets the performer action.
        /// </summary>
        /// <value>
        /// The performer action.
        /// </value>
        public PerformerAction PerformerAction { get; set; }
    }
}
