using ScenarioSim.Performance.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// An factory service used to retrieve the correct evaluator to
    /// evaluate the task performance.
    /// </summary>
    public interface IEvaluatorFactory
    {
        /// <summary>
        /// Makes the proper evaluator for the task performance type.
        /// </summary>
        /// <param name="performance">The task performance.</param>
        /// <returns>An evaluator to evaluate the performance.</returns>
        IEvaluator MakeEvaluator(TaskPerformance performance);
    }
}
