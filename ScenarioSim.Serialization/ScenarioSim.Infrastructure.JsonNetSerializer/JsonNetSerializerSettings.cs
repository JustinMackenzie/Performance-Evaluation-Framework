using Newtonsoft.Json;

namespace ScenarioSim.Infrastructure.JsonNetSerializer
{
    internal static class JsonNetSerializerSettings
    {
        public static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            ContractResolver = new WriteablePropertiesOnlyResolver(),
            TypeNameHandling = TypeNameHandling.Objects,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };
    }
}
