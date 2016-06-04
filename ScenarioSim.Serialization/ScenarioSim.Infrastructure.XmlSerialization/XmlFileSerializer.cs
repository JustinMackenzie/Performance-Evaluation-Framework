using System.IO;
using System.Xml;
using ScenarioSim.Services.Serialization;
using SystemSerializer = System.Xml.Serialization.XmlSerializer;

namespace ScenarioSim.Infrastructure.XmlSerialization
{
    /// <summary>
    /// An implementation of IFileSerializer that serializes to and deserializes from
    /// Xml files.
    /// </summary>
    public class XmlFileSerializer : IFileSerializer
    {
        /// <summary>
        /// Serializes a given object to a file with the given file path.(Including filename)
        /// </summary>
        /// <param name="filename">The path (including filename) of the serialized file to create.</param>
        /// <param name="value">The object to be serialized.</param>
        public void Serialize<T>(string filename, T value)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                SystemSerializer serializer = new SystemSerializer(value.GetType());
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Deserializes a given file to a new object of the desired type.
        /// </summary>
        /// <param name="filename">The path (including filename) of the serialized file.</param>
        /// <returns>A new object of type T with the data from the given serialized file.</returns>
        public T Deserialize<T>(string filename)
        {
            using (XmlTextReader reader = new XmlTextReader(filename))
            {
                SystemSerializer serializer = new SystemSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
