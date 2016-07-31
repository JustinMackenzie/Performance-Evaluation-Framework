using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Task values for a reaction task that has random delay values.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskValues" />
    public class RandomReactionTaskValues : TaskValues
    {
        /// <summary>
        /// Gets or sets the mean delay.
        /// </summary>
        /// <value>
        /// The mean delay.
        /// </value>
        public float MeanDelay { get; set; }

        /// <summary>
        /// Gets or sets the variance delay.
        /// </summary>
        /// <value>
        /// The variance delay.
        /// </value>
        public float VarianceDelay { get; set; }
    }
}
