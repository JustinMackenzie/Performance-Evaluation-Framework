using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEvaluator
    {
        /// <summary>
        /// Evaluates the specified task results.
        /// </summary>
        /// <param name="taskResults">The task results.</param>
        /// <returns></returns>
        TaskPerformanceEvaluation Evaluate(IEnumerable<TaskPerformance> taskResults);
    }
}