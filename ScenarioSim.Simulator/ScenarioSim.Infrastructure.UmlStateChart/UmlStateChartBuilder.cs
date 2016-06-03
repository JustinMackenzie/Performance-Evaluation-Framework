using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;
using UmlStateChart;

namespace ScenarioSim.Infrastructure.UmlStateChart
{
    public class UmlStateChartBuilder : IStateChartBuilder
    {
        protected Dictionary<string, State> states;

        public UmlStateChartBuilder()
        {
            states = new Dictionary<string, State>();
        }

        public IStateChartEngine Build(Scenario scenario)
        {
            string name = scenario.Task.Value.Name;

            StateChart stateChart = new StateChart(name);

            List<TreeNode<Task>> childrenNodes = scenario.Task.children;

            // Add each child state.
            foreach (TreeNode<Task> taskNode in childrenNodes)
                AddState(taskNode, stateChart);

            // Add start state node and history node to state chart.
            PseudoState startState = new PseudoState(string.Format("{0} Start", stateChart), stateChart, PseudoStateType.Start);
            string startTaskName = childrenNodes.First().Value.Name;
            Transition historyTransition = new Transition(startState, states[startTaskName]);

            states.Add(scenario.Task.Value.Name, stateChart);

            // Add all the transitions to the statechart.
            foreach (TaskTransition transition in scenario.TaskTransitions)
                new Transition(states[transition.Source], 
                    states[transition.Destination], new StateChartEvent(transition.EventId));

            return new UmlStateChartEngine(stateChart);
        }

        private void AddState(TreeNode<Task> taskNode, Context parent)
        {
            string name = taskNode.Value.Name;

            // If it is a final task, add it as a final state.
            if (taskNode.Value.Final)
            {
                FinalState state = new FinalState(name, parent);
                states.Add(name, state);
                return;
            }
            
            List<TreeNode<Task>> childNodes = taskNode.children;

            
            // Check if there are children.
            if (childNodes.Count > 0)
            {
                // Create a hierarchical state, since this task has children.
                HierarchicalState state = new HierarchicalState(name, parent, null, null);

                // Recursively add the child tasks.
                foreach (TreeNode<Task> childNode in childNodes)
                    AddState(childNode, state);

                // Add the history and start state nodes for the hierarchical task.
                PseudoState historyState = new PseudoState(state.Name + " History", state, PseudoStateType.History);
                PseudoState startState = new PseudoState(state + " Start", state, PseudoStateType.Start);
                string startTaskName = childNodes.First<TreeNode<Task>>().Value.Name;
                Transition startTransition = new Transition(startState, historyState);
                Transition historyTransition = new Transition(historyState, states[startTaskName]);
                states.Add(name, state);
            }
            else
            {
                // Add a simple state, since this task did not have children.
                State state = new State(name, parent, null, null);
                states.Add(name, state);
            }
        }
    }
}
