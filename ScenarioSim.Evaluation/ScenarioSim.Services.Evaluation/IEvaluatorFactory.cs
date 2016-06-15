using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// An factory service used to retrieve the correct evaluator to
    /// evaluate the task result.
    /// </summary>
    public interface IEvaluatorFactory
    {
        /// <summary>
        /// Makes the proper evaluator for the task result type.
        /// </summary>
        /// <param name="result">The task result.</param>
        /// <returns>An evaluator to evaluate the result.</returns>
        IEvaluator MakeEvaluator(TaskResult result);
    }
}
