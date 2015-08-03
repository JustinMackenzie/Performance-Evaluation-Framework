using System;
using ScenarioSim.Core;

namespace ScenarioSim.UmlStateChart
{
    public enum ActionType
    {
        LogEntry,
        LogExit,
        StartTimer,
        StopTimer,
        LogComplication
    }

    public class ActionFactory
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
