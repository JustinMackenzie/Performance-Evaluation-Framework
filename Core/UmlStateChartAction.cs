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

        public void Execute(StateDataContainer container)
        {
            if (NextAction != null)
                NextAction.Execute(container);
        }

        protected abstract void ExecuteAction(StateDataContainer container);
    }
}
