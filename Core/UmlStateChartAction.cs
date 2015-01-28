using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;

namespace ScenarioSim.Core
{
    abstract class UmlStateChartAction : IAction
    {
        public IAction NextAction { get; set; }

        public abstract void Execute(StateDataContainer container);
    }
}
