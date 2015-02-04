using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmlStateChart;

namespace ScenarioSim.Core
{
    class StopTimerStateExitAction : UmlStateChartAction
    {
        TimeKeeper timeKeeper;
        string name;

        public StopTimerStateExitAction(TimeKeeper timeKeeper, string name)
        {
            this.timeKeeper = timeKeeper;
            this.name = name;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            timeKeeper.StopTimer(name);
        }
    }
}
