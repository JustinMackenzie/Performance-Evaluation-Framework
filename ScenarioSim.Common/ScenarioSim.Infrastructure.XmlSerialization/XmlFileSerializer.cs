using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.XmlSerialization
{
    /// <summary>
    /// An implementation of IFileSerializer that serializes to and deserializes from
    /// Xml files.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized or deserialized.</typeparam>
    public class XmlFileSerializer<T> : IFileSerializer<T>
    {
        /// <summary>
        /// Serializes a given object to a file with the given file path.(Including filename)
        /// </summary>
        /// <param name="filename">The path (including filename) of the serialized file to create.</param>
        /// <param name="value">The object to be serialized.</param>
        public void Serialize(string filename, T value)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                XmlSerializer serializer = new XmlSerializer(value.GetType());
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Deserializes a given file to a new object of the desired type.
        /// </summary>
        /// <param name="filename">The path (including filename) of the serialized file.</param>
        /// <returns>A new object of type T with the data from the given serialized file.</returns>
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
