using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public class Scenario
    {
        public TreeNode<Task> Task{get;set;}
        public List<TaskTransition> TaskTransitions { get; set; }
        public List<Complication> Complications { get; set; }
        public List<Entity> Entities { get; set; }

        public Scenario()
        {
            Complications = new List<Complication>();
            TaskTransitions = new List<TaskTransition>();
            Entities = new List<Entity>();
        }
    }
}
