using System;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.Simulator
{
    public class ScenarioSimulator : IScenarioSimulator
    {
        private readonly IComplicationEnactorRepository enactorRepository;
        private readonly ISimulationComponentRepository componentRepository;
        private readonly IEntityPlacer placer;
        private bool started;

        public ScenarioSimulator(IEntityPlacer placer,
            IComplicationEnactorRepository enactorRepository, ISimulationComponentRepository componentRepository)
            : this(placer, enactorRepository, componentRepository, new ISimulationComponent[] { })
        {
        }

        public ScenarioSimulator(IEntityPlacer placer, IComplicationEnactorRepository enactorRepository,
            ISimulationComponentRepository componentRepository, ISimulationComponent[] components)
        {
            if (placer == null)
                throw new ArgumentNullException(nameof(placer));
            if (enactorRepository == null)
                throw new ArgumentNullException(nameof(enactorRepository));
            if (componentRepository == null)
                throw new ArgumentNullException(nameof(componentRepository));
            if (components == null)
                throw new ArgumentNullException(nameof(components));

            this.enactorRepository = enactorRepository;
            this.componentRepository = componentRepository;
            this.placer = placer;

            foreach (ISimulationComponent component in components)
                componentRepository.AddComponent(component);
        }

        public void Start(Scenario scenario)
        {
            if (scenario == null)
                throw new ArgumentNullException(nameof(scenario));

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
            if(e == null)
                throw new ArgumentNullException(nameof(e));

            if (!started)
                throw new InvalidOperationException("Simulator has not been started. Please call Start() before submitting events.");

            foreach (ISimulationComponent c in componentRepository.GetAllComponents())
                c.SubmitEvent(e);
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            if (enactor == null)
                throw new ArgumentNullException(nameof(enactor));

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
            if (component == null)
                throw new ArgumentNullException(nameof(component));

            componentRepository.AddComponent(component);
        }

        public ISimulationComponent GetComponent(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return componentRepository.GetComponent(type);
        }
    }
}
