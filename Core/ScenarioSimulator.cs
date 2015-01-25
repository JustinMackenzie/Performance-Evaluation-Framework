using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.UmlStateChart;
using ScenarioSim.Utility;

namespace ScenarioSim.Core
{
    class ScenarioSimulator
    {
        ISimulatorEventHandler simulatorEventHandler;
        IStateChartEventHandler stateChartEventHandler;
        IStateChartEngine stateChart;
        public ScenarioSimulator()
        {
            StateChartBuilder builder = new StateChartBuilder();
            TreeNode<Task> rootTask = new TreeNode<Task>(new Task() { Name = "Test Task" });

            stateChart = new UmlStateChartEngine(builder.Build(rootTask));

            List<ISimulatorEventLogger> loggers = new List<ISimulatorEventLogger>();
            loggers.Add(new TextSimulatorEventLogger("SimulatorEvents.txt"));
            loggers.Add(new CsvSimulatorEventLogger("SimulatorEvents.csv"));

            List<IStateChartEventLogger> sLoggers = new List<IStateChartEventLogger>();
            sLoggers.Add(new TextStateChartEventLogger("StateChartEvents.txt"));

            simulatorEventHandler = new SimulatorEventHandler(loggers);
            stateChartEventHandler = new StateChartEventHandler(stateChart, sLoggers);

        }

        public void SubmitSimulatorEvent(SimulatorEvent e)
        {
            simulatorEventHandler.SubmitEvent(e);
            IStateChartEvent stateChartEvent = TransformSimulatorEvent(e);
            stateChartEventHandler.SubmitEvent(stateChartEvent);
        }

        private IStateChartEvent TransformSimulatorEvent(SimulatorEvent e)
        {
            return new UmlStateChartEvent() { Id = e.Id, Name = e.Name, Timestamp = DateTime.Now };
        }
    }
}
