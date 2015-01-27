using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScenarioSim.Core;
using System.IO;

namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class XmlSimulatorEventCollectionSerialzerTests
    {
        string filename;
            int id = 1;
            string name;
            string description;
            DateTime timestamp;
            List<EventParameter> parameters;
            SimulatorEventCollection collection;

        [TestFixtureSetUp]
        public void Initialize()
        {
            filename = "event_collection.xml";
            name = "test event";
            description = "test description";
            timestamp = DateTime.Now;
             parameters = new List<EventParameter>();
            parameters.Add(new EventParameter() { Name = "A parameter", Value = 25 });

            collection = new SimulatorEventCollection();

            for (int i = 0; i < 25; i++)
            {
                collection.Add(new SimulatorEvent()
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Timestamp = timestamp,
                    Parameters = parameters
                });
            }
        }

        [Test]
        public void TestSerialize()
        {
            XmlFileSerializer<SimulatorEventCollection> serializer = new XmlFileSerializer<SimulatorEventCollection>();
            serializer.Serialize(filename, collection);


            Assert.IsTrue(File.Exists(filename));
        }

        [Test]
        public void TestDeserialize()
        {
            XmlFileSerializer<SimulatorEventCollection> serializer = new XmlFileSerializer<SimulatorEventCollection>();
            serializer.Serialize(filename, collection);

            SimulatorEventCollection collection2 = serializer.Deserialize(filename);
            Assert.IsNotNull(collection2);
        }
    }
}
