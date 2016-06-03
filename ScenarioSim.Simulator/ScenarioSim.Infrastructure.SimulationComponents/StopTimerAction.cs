using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class StopTimerAction : IStateChartAction
    {
        private ActionTimeKeeperComponent component;
        private string state;

        public StopTimerAction(ActionTimeKeeperComponent component, string state)
        {
            this.component = component;
            this.state = state;
        }

        public void Execute()
        {
            component.StopTimer(state);
        }
    }
}
