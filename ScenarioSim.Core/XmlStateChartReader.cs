using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ScenarioSim.Core;
using UmlStateChart;

namespace ScenarioSim.UmlStateChart
{
    public class XmlStateChartReader : IStateChartReader
    {
        private Dictionary<int, State> tasks;
        private EventFactory eventFactory;
        private ActionFactory actionFactory;

        public XmlStateChartReader()
        {
            tasks = new Dictionary<int, State>();
            eventFactory = new EventFactory();
            actionFactory = new ActionFactory();
        }

        public IStateChartEngine Read(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            // Get Scenario Name.
            XmlNode scenarioNode = document.SelectSingleNode("scenario");

            // Create the state chart.
            StateChart stateChart = new StateChart(scenarioNode.SelectSingleNode("name").InnerText);

            // Get the xml nodes for the top level tasks.
            XmlNodeList tasksNodeList = scenarioNode.SelectSingleNode("tasks").SelectNodes("task");

            // Add the tasks to the state chart.
            foreach (XmlNode taskNode in tasksNodeList)
            {
                AddTask(taskNode, stateChart);
            }

            // Create start state
            PseudoState start = new PseudoState("Start", stateChart, PseudoStateType.Start);

            // Create end state
            FinalState finalState = new FinalState("Start", stateChart);

            XmlNode finalNode = scenarioNode.SelectSingleNode("final");

            int startingId = int.Parse(scenarioNode.SelectSingleNode("default").InnerText);
            int finalId = int.Parse(finalNode.SelectSingleNode("id").InnerText);
            string finalEventType = finalNode.SelectSingleNode("event").InnerText;

            // Create transitions
            Transition startTransition = new Transition(start, tasks[startingId]);
            Transition endTransition = new Transition(tasks[finalId], finalState, eventFactory.Make(finalEventType));

            XmlNodeList transitionsNodeList = scenarioNode.SelectSingleNode("transitions").SelectNodes("transition");

            foreach (XmlNode transitionNode in transitionsNodeList)
            {
                int sourceId = int.Parse(transitionNode.SelectSingleNode("source").InnerText);
                int destinationId = int.Parse(transitionNode.SelectSingleNode("destination").InnerText);
                string eventType = transitionNode.SelectSingleNode("event").InnerText;
                StateChartEvent stateChartEvent = eventFactory.Make(eventType);

                Transition transition = new Transition(tasks[sourceId], tasks[destinationId], stateChartEvent);
            }

            return new UmlStateChartEngine(stateChart);
        }

        public void AddTask(XmlNode taskNode, Context context)
        {
            // Get the id and name from the file.
            int taskId = int.Parse(taskNode.SelectSingleNode("id").InnerText);
            string taskName = taskNode.SelectSingleNode("name").InnerText;
            IAction enterAction = null;
            IAction exitAction = null;

            // Construct the enter and exit actions.
            if (taskNode.SelectSingleNode("enter") != null)
            {
                string enterActionName = taskNode.SelectSingleNode("enter").InnerText;
                enterAction = actionFactory.Make(enterActionName, taskName);
            }

            if (taskNode.SelectSingleNode("exit") != null)
            {
                string exitActionName = taskNode.SelectSingleNode("exit").InnerText;
                exitAction = actionFactory.Make(exitActionName, taskName);
            }

            // Get the children tasks.
            XmlNodeList childTaskNodes = taskNode.SelectNodes("task");

            // There are children. It is a hierarchical state.
            if (childTaskNodes.Count > 0)
            {
                HierarchicalState result = new HierarchicalState(taskName, context, enterAction, exitAction);
                tasks.Add(taskId, result);

                // Add the children recursively.
                foreach (XmlNode childTaskNode in childTaskNodes)
                {
                    AddTask(childTaskNode, result);
                }

                XmlNode historyNode = taskNode.SelectSingleNode("history");

                PseudoState historyState = null;

                if (historyNode != null)
                {
                    historyState = new PseudoState(taskName + " History", result, PseudoStateType.History);
                }

                PseudoState hierarchyStart = new PseudoState(taskName + " Start", result, PseudoStateType.Start);

                int taskStartingId = int.Parse(taskNode.SelectSingleNode("default").InnerText);

                if (historyState != null)
                {
                    Transition t = new Transition(hierarchyStart, historyState);
                    Transition t1 = new Transition(historyState, tasks[taskStartingId]);
                }
                else
                {
                    Transition t = new Transition(hierarchyStart, tasks[taskStartingId]);
                }
            }
            // There are no children. It is a simple state.
            else
            {
                State result = new State(taskName, context, enterAction, exitAction);

                tasks.Add(taskId, result);
            }
        }
    }
}