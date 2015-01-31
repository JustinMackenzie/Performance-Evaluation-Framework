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
        LogExit,
        StartTimer,
        StopTimer,
        LogComplication
    }

    class ActionFactory
    {
        ILogger logger;
        TimeKeeper keeper;
        ILogger complicationLogger;

        public ActionFactory(ILogger logger, TimeKeeper keeper, ILogger complicationLogger)
        {
            this.logger = logger;
            this.keeper = keeper;
            this.complicationLogger = complicationLogger;
        }
        public UmlStateChartAction Make(ActionType type, string stateName, Complication complication)
        {
            switch(type)
            {
                case ActionType.LogEntry:
                    return new LogStateEntryAction(stateName, logger);
                case ActionType.LogExit:
                    return new LogStateExitAction(stateName, logger);
                case ActionType.StartTimer:
                    return new StartTimerStateEntryAction(keeper, stateName);
                case ActionType.StopTimer:
                    return new StopTimerStateExitAction(keeper, stateName);
                case ActionType.LogComplication:
                    return new LogComplicationAction(complicationLogger, complication);
                default:
                    throw new NotSupportedException();
            }
                
        }
    }
}
