﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;

namespace ScenarioSim.Core
{
    class StartTimerStateEntryAction : UmlStateChartAction
    {
        TimeKeeper timeKeeper;
        string name;

        public StartTimerStateEntryAction(TimeKeeper timeKeeper, string name)
        {
            this.timeKeeper = timeKeeper;
            this.name = name;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            timeKeeper.StartTimer(name);
        }
    }
}
