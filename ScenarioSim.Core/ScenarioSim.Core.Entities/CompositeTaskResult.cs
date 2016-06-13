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
    public class CompositeTaskResult : TaskResult
    {
        /// <summary>
        /// Gets or sets the task results.
        /// </summary>
        /// <value>
        /// The task results.
        /// </value>
        public IEnumerable<TaskResult> TaskResults { get; set; }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public float Time => 1.0f * TaskResults.Sum(r => r.Speed) / 1000;
    }
}
