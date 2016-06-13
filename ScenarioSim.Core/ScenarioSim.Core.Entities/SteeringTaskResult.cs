using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskResult" />
    public class SteeringTaskResult : TaskResult
    {
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time to complete the task.
        /// </value>
        public float Time => 1.0f * Speed / 1000;
    }
}
