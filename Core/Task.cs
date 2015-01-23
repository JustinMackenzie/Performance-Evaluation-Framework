using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    class Task
    {
        public string Name { get; set; }

        public List<TaskTransition> Transition { get; set; }

        public Task()
        {
            Transition = new List<TaskTransition>();
        }
    }
}
