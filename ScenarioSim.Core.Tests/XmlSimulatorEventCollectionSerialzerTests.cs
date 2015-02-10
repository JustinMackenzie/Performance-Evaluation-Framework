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
            EventParameterCollection parameters;
            ScenarioEventCollection collection;

        [TestFixtureSetUp]
        public void Initialize()
        {
            filename = "event_collection.xml";
            name = "test event";
            description = "test description";
            timestamp = DateTime.Now;
             parameters = new EventParameterCollection();
            parameters.Add(new EventParameter() { Name = "A parameter", Value = 25 });

            collection = new ScenarioEventCollection();

            for (int i = 0; i < 25; i++)
            {
                collection.Add(new ScenarioEvent()
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
            XmlFileSerializer<ScenarioEventCollection> serializer = new XmlFileSerializer<ScenarioEventCollection>();
            serializer.Serialize(filename, collection);


            Assert.IsTrue(File.Exists(filename));
        }

        [Test]
        public void TestDeserialize()
        {
            XmlFileSerializer<ScenarioEventCollection> serializer = new XmlFileSerializer<ScenarioEventCollection>();
            serializer.Serialize(filename, collection);

            ScenarioEventCollection collection2 = serializer.Deserialize(filename);
            Assert.IsNotNull(collection2);
        }
    }
}
