using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of 
    /// </summary>
    public class TaskResultEvaluation
    {
        /// <summary>
        /// Gets or sets the task results.
        /// </summary>
        /// <value>
        /// The task results.
        /// </value>
        public IEnumerable<TaskResult> TaskResults { get; set; }

        /// <summary>
        /// Gets or sets the task evaluation values.
        /// </summary>
        /// <value>
        /// The task evaluation values.
        /// </value>
        public TaskEvaluationValues TaskEvaluationValues { get; set; }
    }
}
