using System;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    public class CreateScenarioRequest : ApiRequest
    {
        public string Name { get; set; }

        [JsonIgnore]
        public Guid SchemaId { get; set; }
    }
}