using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluator
{
    /// <summary>
    /// Represents an evaluator that evaluates reaction task results.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.IEvaluator" />
    public class ReactionTaskEvaluator : IEvaluator
    {
        /// <summary>
        /// Evaluates the specified task results.
        /// </summary>
        /// <param name="taskResults">The task results.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TaskResultEvaluation Evaluate(IEnumerable<TaskResult> taskResults)
        {
            throw new NotImplementedException();
        }
    }
}
