using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// The user that has performed a scenario.
    /// </summary>
    public class Performer : Entity
    {
        /// <summary>
        /// Gets or sets the scenario performances.
        /// </summary>
        /// <value>
        /// The scenario performances.
        /// </value>
        public virtual ICollection<ScenarioPerformance> ScenarioPerformances { get; set; } 

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
