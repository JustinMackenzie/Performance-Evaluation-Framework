using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.UmlStateChart;
using ScenarioSim.Utility;

namespace ScenarioSim.Core
{
    public class Scenario
    {
        public TreeNode<Task> Task{get;set;}
        public TaskTransitionCollection TaskTransitions { get; set; }
        public ComplicationCollection Complications { get; set; }
    }
}
