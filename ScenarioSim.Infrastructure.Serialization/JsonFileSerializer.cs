using System.IO;
using Newtonsoft.Json;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.Serialization
{
    class JsonFileSerializer<T> : IFileSerializer<T>
    {
        public T Deserialize(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
        }

        public void Serialize(string filename, T value)
        {
            string json = JsonConvert.SerializeObject(value);

            using(StreamWriter writer = new StreamWriter(filename))
                writer.Write(json);
        }
    }
}
