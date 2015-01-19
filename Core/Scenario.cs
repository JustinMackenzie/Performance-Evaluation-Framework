using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.UmlStateChart;
using ScenarioSim.Utility;

namespace ScenarioSim.Core
{
    class Scenario
    {
        TreeNode<Task> task;

        public Scenario(TreeNode<Task> task)
        {
            this.task = task;
        }
    }
}
