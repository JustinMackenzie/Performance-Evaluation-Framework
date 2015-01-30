﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Utility;
using ScenarioSim.UmlStateChart;
using UmlStateChart;

namespace ScenarioSim.Core
{
    class StateChartBuilder
    {
        Dictionary<string, State> states;
        ActionFactory actionFactory;
        IComplicationEnactorRepository enactorRepo;
        TimeKeeper keeper;

        public StateChartBuilder(IComplicationEnactorRepository enactorRepo, TimeKeeper keeper)
        {
            states = new Dictionary<string, State>();
            this.enactorRepo = enactorRepo;
            this.keeper = keeper;
            actionFactory = new ActionFactory(new TextLogger("StateChartLog.txt"), keeper);
        }

        public StateChart Build(Scenario scenario)
        {
            StateChart stateChart = new StateChart(scenario.Task.Value.Name);

            List<TreeNode<Task>> childrenNodes = scenario.Task.children;

            foreach (TreeNode<Task> taskNode in childrenNodes)
            {
                AddState(taskNode, stateChart);
            }

            PseudoState startState = new PseudoState(stateChart + " Start", stateChart, PseudoStateType.Start);
            string startTaskName = childrenNodes.First<TreeNode<Task>>().Value.Name;
            Transition historyTransition = new Transition(startState, states[startTaskName]);

            states.Add(scenario.Task.Value.Name, stateChart);

            foreach (TaskTransition transition in scenario.TaskTransitions)
                new Transition(states[transition.Source], 
                    states[transition.Destination], new StateChartEvent(transition.EventId));

            AddComplications(scenario.Complications);

            return stateChart;
        }

        private void AddState(TreeNode<Task> taskNode, Context parent)
        {
            string name = taskNode.Value.Name;
            UmlStateChartAction entryAction = actionFactory.Make(ActionType.LogEntry, name);
            UmlStateChartAction exitAction = actionFactory.Make(ActionType.LogExit, name);
            entryAction.AddAction(actionFactory.Make(ActionType.StartTimer, name));
            exitAction.AddAction(actionFactory.Make(ActionType.StopTimer, name));

            List<TreeNode<Task>> childNodes = taskNode.children;

            if (childNodes.Count > 0)
            {
                HierarchicalState state = new HierarchicalState(name, parent, entryAction, exitAction);

                foreach (TreeNode<Task> childNode in childNodes)
                {
                    AddState(childNode, state);
                }

                PseudoState historyState = new PseudoState(state.Name + " History", state, PseudoStateType.History);
                PseudoState startState = new PseudoState(state + " Start", state, PseudoStateType.Start);
                string startTaskName = childNodes.First<TreeNode<Task>>().Value.Name;
                Transition startTransition = new Transition(startState, historyState);
                Transition historyTransition = new Transition(historyState, states[startTaskName]);
                states.Add(name, state);
            }
            else
            {
                State state = new State(name, parent, entryAction, exitAction);
                states.Add(name, state);
            }
        }

        private void AddComplications(ComplicationCollection collection)
        {
            foreach(Complication complication in collection)
            {
                if(complication is TaskDependantComplication)
                {
                    TaskDependantComplication c = complication as TaskDependantComplication;
                    if (c.Entry)
                        (states[c.TaskName].EntryAction as UmlStateChartAction).AddAction(
                            new EnactComplicationAction(enactorRepo, c.Id));
                    else
                        (states[c.TaskName].ExitAction as UmlStateChartAction).AddAction(
                            new EnactComplicationAction(enactorRepo, c.Id));
                }
            }
        }
    }
}
