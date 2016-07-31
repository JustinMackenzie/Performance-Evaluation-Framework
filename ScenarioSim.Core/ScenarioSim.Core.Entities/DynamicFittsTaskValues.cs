using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the task values for a fitts' task that is defined at run time.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskValues" />
    public class DynamicFittsTaskValues : TaskValues
    {
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        /// <value>
        /// The name of the parameter.
        /// </value>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public Vector3f Target { get; set; }
    }
}
