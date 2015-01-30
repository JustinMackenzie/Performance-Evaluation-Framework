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
        StopTimer
    }

    class ActionFactory
    {
        ILogger logger;
        TimeKeeper keeper;

        public ActionFactory(ILogger logger, TimeKeeper keeper)
        {
            this.logger = logger;
            this.keeper = keeper;
        }
        public UmlStateChartAction Make(ActionType type, string stateName)
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
                default:
                    throw new NotSupportedException();
            }
                
        }
    }
}
