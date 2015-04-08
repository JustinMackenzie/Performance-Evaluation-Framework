using NUnit.Framework;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Infrastructure.Serialization;

namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class XmlFileSerializerTest
    {
        [Test]
        public void TestSerializeVector3f()
        {
            Vector3f vector = new Vector3f(1,1,1);
            IFileSerializer<Vector3f> serializer = new XmlFileSerializer<Vector3f>();
            serializer.Serialize("vector.xml", vector);
        }
    }
}
