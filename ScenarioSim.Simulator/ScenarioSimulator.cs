using System;
using System.Collections.Generic;
using ScenarioSim.Core;
using ScenarioSim.UmlStateChart;

namespace ScenarioSim.Simulator
{
    public class ScenarioSimulator : IScenarioSimulator
    {
        protected IStateChartEngine engine;
        protected IComplicationEnactorRepository enactorRepository;
        protected Scenario scenario;
        readonly ISimulationComponentRepository componentRepository;
        private IEntityPlacer placer;
        private IStateChartBuilder builder;

        public SimulationResult Result { get; protected set; }

        public bool IsActive { get { return engine.IsActive; } }

        public ScenarioSimulator(IStateChartBuilder builder, IEntityPlacer placer,
            IComplicationEnactorRepository enactorRepository, ISimulationComponentRepository componentRepository, Scenario scenario)
        {
            this.enactorRepository = enactorRepository;
            this.builder = builder;
            this.componentRepository = componentRepository;
            this.placer = placer;
            this.scenario = scenario;
        }

        public virtual void Start()
        {
            engine = builder.Build(scenario);

            foreach (Entity entity in scenario.Entities)
                placer.Place(entity);

            engine.Start();

            foreach (ISimulationComponent c in componentRepository.GetAllComponents())
                c.Start();
        }

        public void Stop()
        {
            Complete();
        }

        public virtual void SubmitSimulatorEvent(ScenarioEvent e)
        {
            if (!IsActive)
                throw new Exception("Simulator has not been started. Please call Start() before submitting events.");

            engine.Dispatch(TransformSimulatorEvent(e));

            foreach (ISimulationComponent c in componentRepository.GetAllComponents())
                c.SubmitEvent(e);

            if (!IsActive)
                Complete();
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            enactorRepository.AddEnactor(enactor);
        }

        public IEnumerable<string> ActiveTasks()
        {
            return engine.ActiveStates();
        }

        protected IStateChartEvent TransformSimulatorEvent(ScenarioEvent e)
        {
            return new UmlStateChartEvent() { Id = e.Id, Name = e.Name, Timestamp = e.Timestamp };
        }

        protected virtual void Complete()
        {
            foreach (IComplicationEnactor enactor in enactorRepository.Enactors)
                enactor.CleanUp();
            foreach (ISimulationComponent c in componentRepository.GetAllComponents())
                c.Complete();
        }

        public bool IsTaskActive(string task)
        {
            return engine.IsStateActive(task);
        }

        public void AddComponent(ISimulationComponent component)
        {
            componentRepository.AddComponent(component);
        }

        public ISimulationComponent GetComponent(Type type)
        {
            return componentRepository.GetComponent(type);
        }
    }
}
