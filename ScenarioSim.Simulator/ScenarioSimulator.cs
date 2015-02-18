using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.UmlStateChart;
using System.IO;
using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    public class ScenarioSimulator : IScenarioSimulator
    {
        protected IStateChartEngine stateChart;
        protected IComplicationEnactorRepository repo;
        protected Scenario scenario;

        public bool IsActive { get { return stateChart.IsActive; } }

        public ScenarioSimulator(string scenarioFile)
        {
            IFileSerializer<Scenario> serializer = new XmlFileSerializer<Scenario>();
            scenario = serializer.Deserialize(scenarioFile);
            repo = new ComplicationEnactorRepository();
        }

        public virtual void Start()
        {
            ActionFactory actionFactory = new ActionFactory(null, null, null);

            IStateChartBuilder builder = new UmlStateChartBuilder(actionFactory, repo);
            stateChart = builder.Build(scenario);

            stateChart.Start();
        }

        public virtual void SubmitSimulatorEvent(ScenarioEvent e)
        {
            if (!IsActive)
                throw new Exception("Simulator has not been started. Please call Start() before submitting events.");

            stateChart.Dispatch(TransformSimulatorEvent(e));

            if (!IsActive)
                Complete();
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            repo.AddEnactor(enactor);
        }

        public List<string> ActiveTasks()
        {
            return stateChart.ActiveStates();
        }

        protected IStateChartEvent TransformSimulatorEvent(ScenarioEvent e)
        {
            return new UmlStateChartEvent() { Id = e.Id, Name = e.Name, Timestamp = e.Timestamp };
        }

        protected virtual void Complete()
        {

        }

        public bool IsTaskActive(string task)
        {
            return stateChart.IsStateActive(task);
        }
    }
}
