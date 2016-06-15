using System.IO;
using Newtonsoft.Json;
using ScenarioSim.Services.Serialization;

namespace ScenarioSim.Infrastructure.JsonNetSerializer
{
    public class JsonNetFileSerializer : IFileSerializer
    {
        public T Deserialize<T>(string filename)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader reader = new StreamReader(filename))
            using (JsonReader r = new JsonTextReader(reader))
                return (T)serializer.Deserialize(r);
        }

        public void Serialize<T>(string filename, T value)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter streamWriter = new StreamWriter(filename))
                serializer.Serialize(streamWriter, value);
        }
    }
}
