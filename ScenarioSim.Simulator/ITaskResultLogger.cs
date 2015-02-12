using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    interface ITaskResultLogger
    {
        void LogTaskResult(TreeNode<TaskResult> result, string filename);
    }
}
