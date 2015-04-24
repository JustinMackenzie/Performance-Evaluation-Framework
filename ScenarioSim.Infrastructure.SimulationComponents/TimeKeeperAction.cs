using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class TimeKeeperAction : IStateChartAction
    {
        private ActionTimeKeeperComponent component;

        public TimeKeeperAction(ActionTimeKeeperComponent component)
        {
            this.component = component;
        }

        public void Execute()
        {

        }
    }
}
