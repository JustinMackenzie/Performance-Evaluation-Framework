using System;
using ScenarioSim.Core;
using UmlStateChart;

namespace ScenarioSim.UmlStateChart
{
    class LogStateEntryAction : UmlStateChartAction
    {
        string name;
        ILogger logger;

        public LogStateEntryAction(string name, ILogger logger)
        {
            this.name = name;
            this.logger = logger;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            DateTime timestamp = DateTime.Now;

            string message = string.Format("[{0}] Now entering: {1} state.",
                timestamp.ToString(), name);

            logger.Log(message);
        }
    }
}
