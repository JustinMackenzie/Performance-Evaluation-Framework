using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.UmlStateChart;
using ScenarioSim.Utility;

namespace ScenarioSim.Core
{
    public class ScenarioSimulator : IScenarioSimulator
    {
        ISimulatorEventHandler simulatorEventHandler;
        IStateChartEventHandler stateChartEventHandler;
        IStateChartEngine stateChart;
        TrackedEventParameters trackedParameters;
        ParameterKeeper parameterKeeper;
        bool started;
        IComplicationEnactorRepository repo = new ComplicationEnactorRepository();

        public ScenarioSimulator(string scenarioFile)
        {
            IFileSerializer<Scenario> serializer = new XmlFileSerializer<Scenario>();
            Scenario scenario = serializer.Deserialize(scenarioFile);

            StateChartBuilder builder = new StateChartBuilder(repo);
            stateChart = new UmlStateChartEngine(builder.Build(scenario));

            List<ISimulatorEventLogger> loggers = new List<ISimulatorEventLogger>();
            loggers.Add(new TextSimulatorEventLogger("SimulatorEvents.txt"));
            loggers.Add(new CsvSimulatorEventLogger("SimulatorEvents.csv"));

            List<IStateChartEventLogger> sLoggers = new List<IStateChartEventLogger>();
            sLoggers.Add(new TextStateChartEventLogger("StateChartEvents.txt"));

            simulatorEventHandler = new SimulatorEventHandler(loggers);
            stateChartEventHandler = new StateChartEventHandler(stateChart, sLoggers);

            parameterKeeper = new ParameterKeeper();
            trackedParameters = new TrackedEventParameters();

        }

        public void Start()
        {
            stateChart.Start();
            started = true;
        }

        public void SubmitSimulatorEvent(SimulatorEvent e)
        {
            if (!started)
                throw new Exception("Simulator has not been started. Please call Start() before submitting events.");

            simulatorEventHandler.SubmitEvent(e);

            foreach (EventParameter p in e.Parameters)
                if (IsTracked(p, e.Id))
                    parameterKeeper.AddParameter(p, e.Timestamp);

            IStateChartEvent stateChartEvent = TransformSimulatorEvent(e);
            stateChartEventHandler.SubmitEvent(stateChartEvent);
        }

        public void AddTrackedParameter(int eventId, string parameterName)
        {
            trackedParameters.Items.Add(new EventParameterPair() { EventId = eventId, ParameterName = parameterName });
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            repo.AddEnactor(enactor);
        }

        private bool IsTracked(EventParameter parameter, int eventId)
        {
            return (from EventParameterPair p in trackedParameters.Items
                    where p.ParameterName == parameter.Name && p.EventId == eventId
                    select p).Count<EventParameterPair>() > 0;
        }

        private IStateChartEvent TransformSimulatorEvent(SimulatorEvent e)
        {
            return new UmlStateChartEvent() { Id = e.Id, Name = e.Name, Timestamp = DateTime.Now };
        }
    }
}
