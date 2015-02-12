using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScenarioSim.Core;
using NSubstitute;
using System.IO;
using ScenarioSim.Simulator;


namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class ScenarioSimulatorTests
    {
        IScenarioSimulator simulator;
        ScenarioEvent e;

        [SetUp]
        public void Initialize()
        {
            simulator = new ScenarioSimulator("Scenario.xml", "C:\\Users\\Jmac\\Documents", new User() { Id = 1, Name = "Justin" });

            EventParameterCollection parameters = new EventParameterCollection();
            parameters.Add(new EventParameter() { Name = "Tip Position", Value = new Vector3f(5, 2, 7) });
            parameters.Add(new EventParameter() { Name = "Tool Direction", Value = new Vector3f(5, 2, 7) });


            e = new ScenarioEvent()
            {
                Id = 1,
                Name = "Test Event",
                Description = "A description.",
                Timestamp = DateTime.Now,
                Parameters = parameters
            };
        }

        [Test]
        public void TestSubmitEvent()
        {
            simulator.Start();

            simulator.SubmitSimulatorEvent(e);
        }

        [Test]
        public void TestSubmitEvent2()
        {
            e = new ScenarioEvent()
            {
                Id = 5,
                Name = "Change View",
                Description = "The user has switched to change view.",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            simulator.Start();
            simulator.SubmitSimulatorEvent(e);

            Assert.IsTrue(simulator.IsTaskActive("Change View"));
        }

        [Test]
        public void TestComplicationEnacts()
        {
            IComplicationEnactor enactor = Substitute.For<IComplicationEnactor>();
            enactor.ComplicationId.Returns(1);
            simulator.AddEnactor(enactor);

            simulator.Start();

            e = new ScenarioEvent()
            {
                Id = 2,
                Name = "Collision",
                Description = "The user has switched to change view.",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            simulator.SubmitSimulatorEvent(e);

            enactor.Received().Execute();
        }

        [Test]
        public void TestIsNotActive()
        {
            simulator.Start();

            simulator.SubmitSimulatorEvent(e);

            Assert.IsFalse(simulator.IsActive);
        }

        [Test]
        public void TestMadeEventsFile()
        {
            simulator.Start();

            simulator.SubmitSimulatorEvent(e);

            Assert.IsTrue(File.Exists("SimulatorEvents.xml"));
        }
    }
}
