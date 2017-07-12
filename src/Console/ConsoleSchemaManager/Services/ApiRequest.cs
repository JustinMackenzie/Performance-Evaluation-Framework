using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    public abstract class ApiRequest
    {
        [JsonIgnore]
        public string ServerUrl { get; set; }
    }
}