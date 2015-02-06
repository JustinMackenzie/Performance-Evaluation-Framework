using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ScenarioSim.Simulator;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator.Tests
{
    [TestFixture]
    class SimulatorEventTests
    {
        [Test]
        public void TestSerializeEvent()
        {
            IFileSerializer<SimulatorEvent> serializer = new XmlFileSerializer<SimulatorEvent>();

            List<EventParameter> parameters = new List<EventParameter>();
            parameters.Add(new EventParameter()
                {
                    Name = "Test Vector",
                    Value = new Vector3f(1,1,1)
                });

            SimulatorEvent e = new SimulatorEvent()
            {
                Id = 5,
                Name = "Name",
                Description = "Description",
                Timestamp = DateTime.Now,
                Parameters = parameters
            };

            serializer.Serialize("event.xml", e);
        }
    }
}
