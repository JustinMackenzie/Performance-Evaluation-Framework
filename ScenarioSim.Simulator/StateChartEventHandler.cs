using System.Collections.Generic;
using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    class StateChartEventHandler : IStateChartEventHandler
    {
        List<IStateChartEvent> events;
        List<IStateChartEventLogger> loggers;
        IStateChartEngine stateChart;

        public StateChartEventHandler(IStateChartEngine stateChart, List<IStateChartEventLogger> loggers)
        {
            events = new List<IStateChartEvent>();
            this.loggers = loggers;
            this.stateChart = stateChart;
        }

        public void SubmitEvent(IStateChartEvent e)
        {
            events.Add(e);
            foreach (IStateChartEventLogger logger in loggers)
                logger.Log(e);
            stateChart.Dispatch(e);
        }
    }
}
