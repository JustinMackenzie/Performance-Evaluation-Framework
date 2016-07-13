using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents an event that occurs during a scenario performance.
    /// </summary>
    public class PerformerAction
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the performer action parameters.
        /// </summary>
        /// <value>
        /// The performer action parameters.
        /// </value>
        public List<PerformerActionParameter> PerformerActionParameters { get; set; }
    }
}
