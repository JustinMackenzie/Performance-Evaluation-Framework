using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// A factory used to create new task result evaluation objects.
    /// </summary>
    public interface ITaskResultEvaluationFactory
    {
        /// <summary>
        /// Makes the task result evaluation.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        TaskResultEvaluation MakeTaskResultEvaluation(TaskResult result);
    }
}
