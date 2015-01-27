using System;
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

        public StateChartBuilder()
        {
            states = new Dictionary<string, State>();
            actionFactory = new ActionFactory(new TextLogger("StateChartLog.txt"));
        }

        public StateChart Build(TreeNode<Task> rootTask, TaskTransitionCollection transitions)
        {
            StateChart stateChart = new StateChart(rootTask.Value.Name);

            List<TreeNode<Task>> childrenNodes = rootTask.children;

            foreach (TreeNode<Task> taskNode in childrenNodes)
            {
                AddState(taskNode, stateChart);
            }

            PseudoState startState = new PseudoState(stateChart + " Start", stateChart, PseudoStateType.Start);
            string startTaskName = childrenNodes.First<TreeNode<Task>>().Value.Name;
            Transition historyTransition = new Transition(startState, states[startTaskName]);

            states.Add(rootTask.Value.Name, stateChart);

            foreach (TaskTransition transition in transitions)
                new Transition(states[transition.Source], 
                    states[transition.Destination], new StateChartEvent(transition.EventId));

            return stateChart;
        }

        private void AddState(TreeNode<Task> taskNode, Context parent)
        {
            string name = taskNode.Value.Name;
            IAction entryAction = actionFactory.Make(ActionType.LogEntry, name);
            IAction exitAction = actionFactory.Make(ActionType.LogExit, name);

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
    }
}
