using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    interface ITaskResultLogger
    {
        void LogTaskResult(TreeNode<TaskResult> result, string filename);
    }
}
