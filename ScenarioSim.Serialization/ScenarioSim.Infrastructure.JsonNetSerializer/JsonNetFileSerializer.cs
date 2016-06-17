using System.IO;
using Newtonsoft.Json;
using ScenarioSim.Services.Serialization;

namespace ScenarioSim.Infrastructure.JsonNetSerializer
{
    public class JsonNetFileSerializer : IFileSerializer
    {
        public T Deserialize<T>(string filename)
        {
            string content = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(content, JsonNetSerializerSettings.JsonSerializerSettings);
        }

        public void Serialize<T>(string filename, T value)
        {
            string json = JsonConvert.SerializeObject(value, JsonNetSerializerSettings.JsonSerializerSettings);
            File.WriteAllText(filename, json);
        }
    }
}
