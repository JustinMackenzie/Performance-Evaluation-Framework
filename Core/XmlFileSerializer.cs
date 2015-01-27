using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ScenarioSim.Core
{
    public class XmlFileSerializer<T> : IFileSerializer<T>
    {
        public void Serialize(string filename, T value)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                XmlSerializer serializer = new XmlSerializer(value.GetType());
                serializer.Serialize(writer, value);
            }
        }

        public T Deserialize(string filename)
        {
            using (XmlTextReader reader = new XmlTextReader(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
