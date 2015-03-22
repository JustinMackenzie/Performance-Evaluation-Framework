using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.UmlStateChart;
using System.IO;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class ScenarioSimulator : IScenarioSimulator
    {
        protected IStateChartEngine stateChart;
        protected IComplicationEnactorRepository repo;
        protected Scenario scenario;
        IEntityPlacer placer;
        Dictionary<Type, ISimulationComponent> components;

        public SimulationResult Result { get; protected set; }

        public bool IsActive { get { return stateChart.IsActive; } }

        public ScenarioSimulator(string scenarioFile, IEntityPlacer placer)
        {
            IFileSerializer<Scenario> serializer = new XmlFileSerializer<Scenario>();
            scenario = serializer.Deserialize(scenarioFile);
            repo = new ComplicationEnactorRepository();

            components = new Dictionary<Type, ISimulationComponent>();

            this.placer = placer;

            foreach (Entity entity in scenario.Entities)
                placer.Place(entity);
        }

        public virtual void Start()
        {
            ActionFactory actionFactory = new ActionFactory(null, null, null);

            IStateChartBuilder builder = new UmlStateChartBuilder(actionFactory, repo);
            stateChart = builder.Build(scenario);

            stateChart.Start();
            foreach (ISimulationComponent c in components.Values)
                c.Start();
        }

        public virtual void SubmitSimulatorEvent(ScenarioEvent e)
        {
            if (!IsActive)
                throw new Exception("Simulator has not been started. Please call Start() before submitting events.");

            stateChart.Dispatch(TransformSimulatorEvent(e));

            foreach (ISimulationComponent c in components.Values)
                c.SubmitEvent(e);

            if (!IsActive)
                Complete();
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            repo.AddEnactor(enactor);
        }

        public IEnumerable<string> ActiveTasks()
        {
            return stateChart.ActiveStates();
        }

        protected IStateChartEvent TransformSimulatorEvent(ScenarioEvent e)
        {
            return new UmlStateChartEvent() { Id = e.Id, Name = e.Name, Timestamp = e.Timestamp };
        }

        protected virtual void Complete()
        {
            foreach (IComplicationEnactor enactor in repo.Enactors)
                enactor.CleanUp();
            foreach (ISimulationComponent c in components.Values)
                c.Complete();
        }

        public bool IsTaskActive(string task)
        {
            return stateChart.IsStateActive(task);
        }


        public void AddComponent(ISimulationComponent component)
        {
            components.Add(component.GetType(), component);
        }


        public ISimulationComponent GetComponent(Type type)
        {
            if (!components.ContainsKey(type))
                return null;
            return components[type];
        }
    }
}
