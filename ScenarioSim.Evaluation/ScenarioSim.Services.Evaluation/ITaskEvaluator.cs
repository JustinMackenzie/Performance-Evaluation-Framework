using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    public interface ITaskEvaluator
    {
        /// <summary>
        /// Evaluates the user history.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="scenario">The scenario.</param>
        /// <param name="windowSize">Size of the window.</param>
        /// <returns></returns>
        IEnumerable<TaskPerformanceEvaluation> EvaluateUserHistory(User user, Scenario scenario, int windowSize);

        /// <summary>
        /// Evaluates the results.
        /// </summary>
        /// <param name="taskResults">The task results.</param>
        /// <returns>The evaluation of the results.</returns>
        TaskPerformanceEvaluation EvaluateTaskResults(IEnumerable<TaskPerformance> taskResults);

        /// <summary>
        /// Evaluates the scenario results.
        /// </summary>
        /// <param name="scenarioResults">The scenario results.</param>
        /// <returns></returns>
        ScenarioPerformanceEvaluation EvaluateScenarioResults(IEnumerable<ScenarioPerformance> scenarioResults);
    }
}
