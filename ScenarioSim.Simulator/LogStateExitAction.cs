using System;
using ScenarioSim.Core;
using UmlStateChart;

namespace ScenarioSim.UmlStateChart
{
    class LogStateExitAction : UmlStateChartAction
    {
        string name;
        ILogger logger;

        public LogStateExitAction(string name, ILogger logger)
        {
            this.name = name;
            this.logger = logger;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            DateTime timestamp = DateTime.Now;

            string message = string.Format("[{0}] Now exiting: {1} state.",
                timestamp.ToString(), name);

            logger.Log(message);
        }
    }
}
