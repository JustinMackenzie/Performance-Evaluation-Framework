using System;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.Simulator
{
    public class ScenarioSimulator : IScenarioSimulator
    {
        protected IComplicationEnactorRepository enactorRepository;
        readonly ISimulationComponentRepository componentRepository;
        private IEntityPlacer placer;
        private bool started;

        public ScenarioSimulator(IEntityPlacer placer,
            IComplicationEnactorRepository enactorRepository, ISimulationComponentRepository componentRepository)
        {
            this.enactorRepository = enactorRepository;
            this.componentRepository = componentRepository;
            this.placer = placer;
        }

        public void Start(Scenario scenario)
        {
            foreach (Entity entity in scenario.Entities)
                placer.Place(entity);

            foreach (ISimulationComponent c in componentRepository.GetAllComponents())
                c.Start(scenario);

            started = true;
        }

        public void Stop()
        {
            Complete();
        }

        public void SubmitSimulatorEvent(ScenarioEvent e)
        {
            if (!started)
                throw new Exception("Simulator has not been started. Please call Start() before submitting events.");

            foreach (ISimulationComponent c in componentRepository.GetAllComponents())
                c.SubmitEvent(e);
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            enactorRepository.AddEnactor(enactor);
        }

        protected void Complete()
        {
            foreach (IComplicationEnactor enactor in enactorRepository.Enactors)
                enactor.CleanUp();
            foreach (ISimulationComponent c in componentRepository.GetAllComponents())
                c.Complete();
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
