using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.Simulator.Tests
{
    [TestFixture]
    public class ScenarioSimulatorTests
    {
        private IStateChartEngine engine;
        private IStateChartBuilder builder;
        private IEntityPlacer placer;
        private IComplicationEnactorRepository repository;
        private ISimulationComponentRepository componentRepository;
        private IScenarioSimulator simulator;
        private Scenario scenario;
        private Random random;

        [SetUp]
        public void Initialize()
        {
            random = new Random();
            builder = Substitute.For<IStateChartBuilder>();
            engine = Substitute.For<IStateChartEngine>();
            placer = Substitute.For<IEntityPlacer>();
            repository = Substitute.For<IComplicationEnactorRepository>();
            componentRepository = Substitute.For<ISimulationComponentRepository>();

            

            scenario = new Scenario()
            {
                Entities = new List<Entity>()
            };

            builder.Build(scenario).Returns(engine);

            simulator = new ScenarioSimulator(builder, placer, repository, componentRepository);
        }

        [Test]
        public void TestBuildStateChart()
        {
            simulator.Start(scenario);

            builder.Received().Build(scenario);
        }

        [Test]
        public void TestStartStateChart()
        {
            simulator.Start(scenario);
           
            engine.Received().Start();
        }

        [Test]
        public void TestPlaceEntities()
        {
            int n = random.Next(100);

            for (int i = 0; i < n; i++)
                scenario.Entities.Add(new Entity());

            simulator.Start(scenario);

            foreach (Entity entity in scenario.Entities)
                placer.Received().Place(entity);

        }

        [Test]
        public void TestStartComponents()
        {
            List<ISimulationComponent> components = new List<ISimulationComponent>();

            int n = random.Next(100);

            for (int i = 0; i < n; i++)
                components.Add(Substitute.For<ISimulationComponent>());

            componentRepository.GetAllComponents().Returns(components);

            simulator.Start(scenario);

            foreach (ISimulationComponent simulationComponent in components)
                simulationComponent.Received().Start();
        }

        [Test]
        public void TestCleanUpEnactors()
        {
            List<IComplicationEnactor> enactors = new List<IComplicationEnactor>();

            int n = random.Next(100);

            for (int i = 0; i < n; i++)
            {
                enactors.Add(Substitute.For<IComplicationEnactor>());
            }

            repository.Enactors.Returns(enactors);

            simulator.Start(scenario);

            simulator.Stop();

            foreach (IComplicationEnactor enactor in enactors)
            {
                enactor.Received().CleanUp();
            }
        }

        [Test]
        public void TestCompleteComponents()
        {
            List<ISimulationComponent> components = new List<ISimulationComponent>();

            int n = random.Next(100);

            for (int i = 0; i < n; i++)
                components.Add(Substitute.For<ISimulationComponent>());

            componentRepository.GetAllComponents().Returns(components);

            simulator.Start(scenario);

            simulator.Stop();

            foreach (ISimulationComponent simulationComponent in components)
                simulationComponent.Received().Complete();
        }
    }
}
