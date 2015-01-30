using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScenarioSim.Core;
using NSubstitute;
using System.IO;


namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class ScenarioSimulatorTests
    {
        IScenarioSimulator simulator;
        SimulatorEvent e;

        [SetUp]
        public void Initialize()
        {
            simulator = new ScenarioSimulator("Scenario.xml", "C:\\Users\\Jmac\\Documents");

            List<EventParameter> parameters = new List<EventParameter>();
            parameters.Add(new EventParameter() { Name = "Tip Location", Value = new Vector3f(5, 2, 7) });


            e = new SimulatorEvent()
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
        public void TestComplicationEnacts()
        {

            IComplicationEnactor enactor = Substitute.For<IComplicationEnactor>();
            enactor.ComplicationId.Returns(1);
            simulator.AddEnactor(enactor);

            simulator.Start();

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
