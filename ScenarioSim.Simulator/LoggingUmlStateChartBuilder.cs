using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;
using UmlStateChart;
using ScenarioSim.UmlStateChart;

namespace ScenarioSim.Simulator
{
    public class LoggingUmlStateChartBuilder : UmlStateChartBuilder
    {
        public LoggingUmlStateChartBuilder(ActionFactory actionFactory, IComplicationEnactorRepository repo) : base(actionFactory, repo) { }

        protected override void AddActions(State state)
        {
            UmlStateChartAction entryAction = actionFactory.Make(ActionType.LogEntry, state.Name, null);
            UmlStateChartAction exitAction = actionFactory.Make(ActionType.LogExit, state.Name, null);

            entryAction.AddAction(actionFactory.Make(ActionType.StartTimer, state.Name, null));
            exitAction.AddAction(actionFactory.Make(ActionType.StopTimer, state.Name, null));

            state.EntryAction = entryAction;
            state.ExitAction = exitAction;
        }

        protected override void AddComplicationActions(Complication complication)
        {
            if (complication is TaskDependantComplication)
            {
                TaskDependantComplication c = complication as TaskDependantComplication;
                if (c.Entry)
                {
                    UmlStateChartAction action = states[c.TaskName].EntryAction as UmlStateChartAction;

                    if (action == null)
                    {
                        states[c.TaskName].EntryAction = actionFactory.Make(ActionType.LogComplication, null, c);
                    }
                    else
                    {
                        action.AddAction(actionFactory.Make(ActionType.LogComplication, null, c));
                    }

                    (states[c.TaskName].EntryAction as UmlStateChartAction).AddAction(
                        new EnactComplicationAction(repo, c.Id));
                }
                else
                {
                    UmlStateChartAction action = states[c.TaskName].ExitAction as UmlStateChartAction;

                    if (action == null)
                    {
                        states[c.TaskName].ExitAction = actionFactory.Make(ActionType.LogComplication, null, c);
                    }
                    else
                    {
                        action.AddAction(actionFactory.Make(ActionType.LogComplication, null, c));
                    }

                    (states[c.TaskName].ExitAction as UmlStateChartAction).AddAction(
                        new EnactComplicationAction(repo, c.Id));
                }
            }
        }
    }
}
