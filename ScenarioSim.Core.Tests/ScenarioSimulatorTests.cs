using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScenarioSim.Core;

namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class ScenarioSimulatorTests
    {
        [Test]
        public void TestSubmitEvent()
        {
            IScenarioSimulator simulator = new ScenarioSimulator("Task Tree.xml", "Task Transitions.xml");

            List<EventParameter> parameters = new List<EventParameter>();
            parameters.Add(new EventParameter() { Name = "Tip Location", Value = new Vector3f(5, 2, 7) });


            SimulatorEvent e = new SimulatorEvent() 
            {
                Id = 1, 
                Name = "Test Event",
                Description = "A description.", 
                Timestamp = DateTime.Now,
                Parameters = parameters
            };

            simulator.Start();

            simulator.SubmitSimulatorEvent(e);
        }
    }
}
