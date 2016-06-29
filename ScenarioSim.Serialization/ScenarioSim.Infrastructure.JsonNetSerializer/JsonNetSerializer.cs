using Newtonsoft.Json;
using ScenarioSim.Services.Serialization;

namespace ScenarioSim.Infrastructure.JsonNetSerializer
{
    public class JsonNetSerializer : ISerializer
    {
        public static string SerializeObject<T>(T value)
        {
            return JsonConvert.SerializeObject(value, JsonNetSerializerSettings.JsonSerializerSettings);
        }

        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, JsonNetSerializerSettings.JsonSerializerSettings);
        }

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, JsonNetSerializerSettings.JsonSerializerSettings);
        }

        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, JsonNetSerializerSettings.JsonSerializerSettings);
        }
    }
}
