using System;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents a transition from one task to another.
    /// </summary>
    public class EfTaskTransition : EfEntity
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
        public virtual EfSchema Schema { get; set; }

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
        public virtual EfTask SourceTask { get; set; }

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
        public virtual EfTask DestinationTask { get; set; }

        /// <summary>
        /// Gets or sets the performer action identifier.
        /// </summary>
        /// <value>
        /// The performer action identifier.
        /// </value>
        public Guid PerformerActionId { get; set; }
    }
}