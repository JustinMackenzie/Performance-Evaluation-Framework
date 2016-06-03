using ScenarioSim.Services.Simulator;
using UmlStateChart;

namespace ScenarioSim.Infrastructure.UmlStateChart
{
    public class UmlStateChartAction : IAction
    {
        private readonly IStateChartAction action;

        public UmlStateChartAction(IStateChartAction action)
        {
            this.action = action;
        }

        public UmlStateChartAction NextAction { get; set; }

        public void Execute(StateDataContainer container)
        {
            action.Execute();

            if (NextAction != null)
                NextAction.Execute(container);
        }

        public void AddAction(UmlStateChartAction action)
        {
            if (NextAction != null)
                NextAction.AddAction(action);
            else
                NextAction = action;
        }
    }
}
