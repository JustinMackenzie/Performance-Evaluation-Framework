using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;
using ScenarioSim.Core;

namespace ScenarioSim.UmlStateChart
{
    enum ActionType
    {
        LogEntry,
        LogExit
    }

    class ActionFactory
    {
        ILogger logger;

        public ActionFactory(ILogger logger)
        {
            this.logger = logger;
        }
        public IAction Make(ActionType type, string stateName)
        {
            switch(type)
            {
                case ActionType.LogEntry:
                    return new LogStateEntryAction(stateName, logger);
                case ActionType.LogExit:
                    return new LogStateExitAction(stateName, logger);
                default:
                    throw new NotSupportedException();
            }
                
        }
    }
}
