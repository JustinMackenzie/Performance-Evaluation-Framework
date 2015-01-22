using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Utility;

namespace ScenarioSim.Core
{
    class TaskTreeNode : TreeNode<Task>
    {
        public TaskTreeNode(Task task) : base(task) { }
    }
}
