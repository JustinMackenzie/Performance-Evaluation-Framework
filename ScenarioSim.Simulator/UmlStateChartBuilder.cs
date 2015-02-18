using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.UmlStateChart;
using UmlStateChart;
using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    public class UmlStateChartBuilder : IStateChartBuilder
    {
        protected Dictionary<string, State> states;
        protected ActionFactory actionFactory;
        protected IComplicationEnactorRepository repo;

        public UmlStateChartBuilder(ActionFactory actionFactory, IComplicationEnactorRepository repo)
        {
            states = new Dictionary<string, State>();
            this.actionFactory = actionFactory;
            this.repo = repo;
        }

        public IStateChartEngine Build(Scenario scenario)
        {
            string name = scenario.Task.Value.Name;

            StateChart stateChart = new StateChart(name);

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

            return new UmlStateChartEngine(stateChart);
        }

        protected virtual void AddActions(State state)
        {
            
        }

        private void AddState(TreeNode<Task> taskNode, Context parent)
        {
            string name = taskNode.Value.Name;

            if (taskNode.Value.Final)
            {
                FinalState state = new FinalState(name, parent);
                states.Add(name, state);
                return;
            }

            List<TreeNode<Task>> childNodes = taskNode.children;

            if (childNodes.Count > 0)
            {
                HierarchicalState state = new HierarchicalState(name, parent, null, null);

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
                AddActions(state);
            }
            else
            {
                State state = new State(name, parent, null, null);
                states.Add(name, state);
                AddActions(state);
            }
        }

        protected virtual void AddComplicationActions(Complication complication)
        {
            if (complication is TaskDependantComplication)
            {
                TaskDependantComplication c = complication as TaskDependantComplication;
                if (c.Entry)
                    states[c.TaskName].EntryAction = new EnactComplicationAction(repo, c.Id);
                
                else
                    states[c.TaskName].ExitAction = new EnactComplicationAction(repo, c.Id);
            }
        }

        private void AddComplications(List<Complication> collection)
        {
            foreach(Complication complication in collection)
            {
                AddComplicationActions(complication);
            }
        }
    }
}
