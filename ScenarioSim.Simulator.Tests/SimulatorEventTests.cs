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
            IFileSerializer<ScenarioEvent> serializer = new XmlFileSerializer<ScenarioEvent>();

            EventParameterCollection parameters = new EventParameterCollection();
            parameters.Add(new EventParameter()
                {
                    Name = "Test Vector",
                    Value = new Vector3f(1,1,1)
                });

            ScenarioEvent e = new ScenarioEvent()
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
