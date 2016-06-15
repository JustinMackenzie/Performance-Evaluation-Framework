using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    public interface IEvaluator
    {
        TaskResultEvaluation Evaluate(TaskResult task);
    }
}