using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    public interface ITaskEvaluator
    {
        /// <summary>
        /// Evaluates the user history.
        /// </summary>
        /// <param name="performer">The user.</param>
        /// <param name="scenario">The scenario.</param>
        /// <param name="windowSize">Size of the window.</param>
        /// <returns></returns>
        IEnumerable<TaskPerformanceEvaluation> EvaluateUserHistory(Performer performer, Scenario scenario, int windowSize);

        /// <summary>
        /// Evaluates the results.
        /// </summary>
        /// <param name="taskResults">The task results.</param>
        /// <returns>The evaluation of the results.</returns>
        TaskPerformanceEvaluation EvaluateTaskResults(IEnumerable<TaskPerformance> taskResults);

        /// <summary>
        /// Evaluates the scenario performances.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="scenarioPerformances">The scenario performances.</param>
        /// <returns></returns>
        PerformanceEvaluation EvaluateScenarioPerformances(Schema schema, IEnumerable<ScenarioPerformance> scenarioPerformances);
    }
}
