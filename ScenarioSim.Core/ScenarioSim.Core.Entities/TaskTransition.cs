﻿using System;

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
        /// Gets or sets the source identifier.
        /// </summary>
        /// <value>
        /// The source identifier.
        /// </value>
        public Guid SourceId { get; set; }

        /// <summary>
        /// Gets or sets the destination identifier.
        /// </summary>
        /// <value>
        /// The destination identifier.
        /// </value>
        public Guid DestinationId { get; set; }

        /// <summary>
        /// Gets or sets the performer action identifier.
        /// </summary>
        /// <value>
        /// The performer action identifier.
        /// </value>
        public Guid PerformerActionId { get; set; }
    }
}
