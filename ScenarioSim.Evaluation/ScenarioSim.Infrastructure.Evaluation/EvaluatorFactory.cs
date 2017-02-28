using System;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;
using ScenarioSim.Performance.Entities;

namespace ScenarioSim.Infrastructure.Evaluation
{
    /// <summary>
    /// Represents an implementation of the evaluator factory.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.IEvaluatorFactory" />
    public class EvaluatorFactory : IEvaluatorFactory
    {
        /// <summary>
        /// Makes the proper evaluator for the task performance type.
        /// </summary>
        /// <param name="performance">The task performance.</param>
        /// <returns>
        /// An evaluator to evaluate the performance.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">The given task does not have an associated evaluator.</exception>
        public IEvaluator MakeEvaluator(TaskPerformance performance)
        {
            if (performance.Task.TaskValues is FittsTaskValues)
            {
                return new FittsEvaluator();
            }

            throw new InvalidOperationException("The given task does not have an associated evaluator.");
        }
    }
}
