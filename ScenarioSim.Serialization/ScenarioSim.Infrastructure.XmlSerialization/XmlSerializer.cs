using System.IO;
using ScenarioSim.Services.Serialization;
using SystemXmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace ScenarioSim.Infrastructure.XmlSerialization
{
    public class XmlSerializer : ISerializer
    {
        public string Serialize<T>(T value)
        {
            SystemXmlSerializer serializer = new SystemXmlSerializer(typeof(T));

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, value);
                return writer.ToString();
            }
        }

        public T Deserialize<T>(string value)
        {
            SystemXmlSerializer serializer = new SystemXmlSerializer(typeof (T));

            using (StringReader reader = new StringReader(value))
            {
                return (T) serializer.Deserialize(reader);
            }
        }
    }
}
