using ScenarioSim.Core.Entities;
using ScenarioSim.Evaluation.Entities;
using ScenarioSim.Performance.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// A factory used to create new task performance evaluation objects.
    /// </summary>
    public interface ITaskResultEvaluationFactory
    {
        /// <summary>
        /// Makes the task performance evaluation.
        /// </summary>
        /// <param name="performance">The performance.</param>
        /// <returns></returns>
        TaskPerformanceEvaluation MakeTaskResultEvaluation(TaskPerformance performance);
    }
}
