using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    class StartTimerAction : IStateChartAction
    {
        private ActionTimeKeeperComponent component;
        private string state;

        public StartTimerAction(ActionTimeKeeperComponent component, string state)
        {
            this.component = component;
            this.state = state;
        }

        public void Execute()
        {
            component.StartTimer(state);
        }
    }
}
