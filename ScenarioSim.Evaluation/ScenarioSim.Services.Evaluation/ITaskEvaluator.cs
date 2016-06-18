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
        IEnumerable<TaskResultEvaluation> EvaluateUserHistory(User user, Scenario scenario, int windowSize);

        /// <summary>
        /// Evaluates the results.
        /// </summary>
        /// <param name="taskResults">The task results.</param>
        /// <returns>The evaluation of the results.</returns>
        TaskResultEvaluation EvaluateTaskResults(IEnumerable<TaskResult> taskResults);

        /// <summary>
        /// Evaluates the scenario results.
        /// </summary>
        /// <param name="scenarioResults">The scenario results.</param>
        /// <returns></returns>
        ScenarioResultEvaluation EvaluateScenarioResults(IEnumerable<ScenarioResult> scenarioResults);
    }
}
