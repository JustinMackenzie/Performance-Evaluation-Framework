using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskEvaluatorFactory
    {
        /// <summary>
        /// Makes the task evaluator.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        ITaskEvaluator MakeTaskEvaluator(Task task);
    }
}
