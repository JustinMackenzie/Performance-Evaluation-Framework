using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    interface ITaskResultLogger
    {
        void LogTaskResult(TreeNode<TaskResult> result, string filename);
    }
}
