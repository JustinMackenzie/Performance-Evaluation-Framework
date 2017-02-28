using System.Collections.Generic;
using ScenarioSim.Evaluation.Entities;
using ScenarioSim.Performance.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPerformanceEvaluator
    {
        /// <summary>
        /// Gets the performances evaluation.
        /// </summary>
        /// <param name="performances">The performances.</param>
        /// <returns></returns>
        PerformanceEvaluation GetPerformanceEvaluation(IEnumerable<ScenarioPerformance> performances);
    }
}
