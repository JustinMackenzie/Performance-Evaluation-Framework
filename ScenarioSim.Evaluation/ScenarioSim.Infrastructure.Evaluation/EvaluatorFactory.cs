using System;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluator
{
    /// <summary>
    /// Represents an implementation of the evaluator factory.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.IEvaluatorFactory" />
    public class EvaluatorFactory : IEvaluatorFactory
    {
        /// <summary>
        /// Makes the proper evaluator for the task result type.
        /// </summary>
        /// <param name="result">The task result.</param>
        /// <returns>
        /// An evaluator to evaluate the result.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">The given task does not have an associated evaluator.</exception>
        public IEvaluator MakeEvaluator(TaskResult result)
        {
            if (result.Task.TaskValues is FittsTaskValues)
            {
                return new FittsEvaluator();
            }

            throw new InvalidOperationException("The given task does not have an associated evaluator.");
        }
    }
}
