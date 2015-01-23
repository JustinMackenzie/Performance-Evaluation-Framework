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

        public StateChartBuilder()
        {
            states = new Dictionary<string, State>();
        }

        public StateChart Build(TreeNode<Task> rootTask)
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

            Action<Task> action = AddTransition;

            rootTask.Traverse(action);

            return stateChart;
        }

        private void AddTransition(Task task)
        {
            State state = states[task.Name];

            foreach(TaskTransition transition in task.Transition)
                new Transition(state,
                    states[transition.NextTask.Name],
                    new StateChartEvent(transition.Id));
        }

        private void AddState(TreeNode<Task> taskNode, Context parent)
        {
            string name = taskNode.Value.Name;
            IAction entryAction = null;
            IAction exitAction = null;

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
