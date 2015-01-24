using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;

namespace ScenarioSim.Core
{
    class LogStateEntryAction : IAction
    {
        string name;
        ILogger logger;

        public LogStateEntryAction(string name, ILogger logger)
        {
            this.name = name;
            this.logger = logger;
        }

        public void Execute(StateDataContainer dataContainer)
        {
            DateTime timestamp = DateTime.Now;

            string message = string.Format("[{0}] Now entering: {1} state.", 
                timestamp.ToString(), name);

            logger.Log(message);
        }
    }
}
