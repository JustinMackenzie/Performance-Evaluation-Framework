using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;

namespace ScenarioSim.Core
{
    class LogComplicationAction : UmlStateChartAction
    {
        ILogger logger;
        Complication complication;

        public LogComplicationAction(ILogger logger, Complication complication)
        {
            this.logger = logger;
            this.complication = complication;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            string message = string.Format("[{0}] Complication {1}: {2} has arisen.", 
                DateTime.Now, complication.Id, complication.Name);
            logger.Log(message);
        }
    }
}
