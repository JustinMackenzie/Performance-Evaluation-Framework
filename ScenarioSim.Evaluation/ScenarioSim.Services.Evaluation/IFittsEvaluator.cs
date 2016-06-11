using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    public interface IFittsEvaluator
    {
        /// <summary>
        /// Evaluates the user history.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="scenario">The scenario.</param>
        /// <param name="windowSize">Size of the window.</param>
        /// <returns></returns>
        IEnumerable<FittsEvaluationResult> EvaluateUserHistory(User user, Scenario scenario, int windowSize);

        /// <summary>
        /// Evaluates the results.
        /// </summary>
        /// <param name="fittsTaskResultPairs">The fitts task result pairs.</param>
        /// <returns>The evaluation of the results.</returns>
        FittsTaskResultEvaluation EvaluateResults(List<FittsTaskResultPair> fittsTaskResultPairs);
    }
}
