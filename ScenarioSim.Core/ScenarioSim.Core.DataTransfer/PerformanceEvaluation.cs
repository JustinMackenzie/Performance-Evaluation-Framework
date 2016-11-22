using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.DataTransfer
{
    public class PerformanceEvaluation
    {
        /// <summary>
        /// Gets or sets the task performance evaluations.
        /// </summary>
        /// <value>
        /// The task performance evaluations.
        /// </value>
        public Dictionary<Guid, TaskPerformanceEvaluation> TaskPerformanceEvaluations { get; set; }
    }
}
