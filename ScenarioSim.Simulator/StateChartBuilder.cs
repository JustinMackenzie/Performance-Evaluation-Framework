using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.UmlStateChart;
using UmlStateChart;

namespace ScenarioSim.Core
{
    class StateChartBuilder
    {
        Dictionary<string, State> states;
        ActionFactory actionFactory;
        IComplicationEnactorRepository repo;
        IStateChartEngine engine;

        public StateChartBuilder(IStateChartEngine engine, ActionFactory actionFactory, IComplicationEnactorRepository repo)
        {
            states = new Dictionary<string, State>();
            this.actionFactory = actionFactory;
            this.repo = repo;
            this.engine = engine;
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
            UmlStateChartAction entryAction = actionFactory.Make(ActionType.LogEntry, name, null);
            UmlStateChartAction exitAction = actionFactory.Make(ActionType.LogExit, name, null);

            if (taskNode.Value.Final)
            {
                FinalState state = new FinalState(name, parent);
                states.Add(name, state);
                return;
            }

            entryAction.AddAction(actionFactory.Make(ActionType.StartTimer, name, null));
            exitAction.AddAction(actionFactory.Make(ActionType.StopTimer, name, null));

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

        private void AddComplications(List<Complication> collection)
        {
            foreach(Complication complication in collection)
            {
                if(complication is TaskDependantComplication)
                {
                    TaskDependantComplication c = complication as TaskDependantComplication;
                    if (c.Entry)
                    {
                        (states[c.TaskName].EntryAction as UmlStateChartAction).AddAction(
                            actionFactory.Make(ActionType.LogComplication, null, c));
                        (states[c.TaskName].EntryAction as UmlStateChartAction).AddAction(
                            new EnactComplicationAction(repo, c.Id));
                    }
                    else
                    {
                        (states[c.TaskName].ExitAction as UmlStateChartAction).AddAction(
                            actionFactory.Make(ActionType.LogComplication, null, c));
                        (states[c.TaskName].ExitAction as UmlStateChartAction).AddAction(
                            new EnactComplicationAction(repo, c.Id));
                    }
                }
            }
        }
    }
}
