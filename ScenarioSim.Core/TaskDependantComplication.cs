using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public class TaskDependantComplication : Complication
    {
        public string TaskName { get; set; }
        public bool Entry { get; set; }
    }
}
