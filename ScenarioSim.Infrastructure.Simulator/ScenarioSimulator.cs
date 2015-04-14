using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.Simulator
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
            IComplicationEnactorRepository enactorRepository, ISimulationComponentRepository componentRepository)
        {
            this.enactorRepository = enactorRepository;
            this.builder = builder;
            this.componentRepository = componentRepository;
            this.placer = placer;
        }

        public virtual void Start(Scenario scenario)
        {
            engine = builder.Build(scenario);
            this.scenario = scenario;

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

            engine.Dispatch(engine.MakeStateChartEvent(e));

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
