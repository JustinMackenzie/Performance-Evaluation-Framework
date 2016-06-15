using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the performance result of a reaction task.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskResult" />
    public class ReactionTaskResult : TaskResult
    {
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time to complete the task in seconds.
        /// </value>
        public float Time => 1.0f * ElapsedTime / 1000;
    }
}
