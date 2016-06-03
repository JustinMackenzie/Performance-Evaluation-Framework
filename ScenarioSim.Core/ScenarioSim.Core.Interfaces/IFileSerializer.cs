namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// Represents an abstract serializer that serializes data to a file and 
    /// deserializes data from a file.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized or deserialized.</typeparam>
    public interface IFileSerializer<T>
    {
        /// <summary>
        /// Deserializes a given file to a new object of the desired type.
        /// </summary>
        /// <param name="filename">The path (including filename) of the serialized file.</param>
        /// <returns>A new object of type T with the data from the given serialized file.</returns>
        T Deserialize(string filename);

        /// <summary>
        /// Serializes a given object to a file with the given file path.(Including filename)
        /// </summary>
        /// <param name="filename">The path (including filename) of the serialized file to create.</param>
        /// <param name="value">The object to be serialized.</param>
        void Serialize(string filename, T value);
    }
}
