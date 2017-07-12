using System;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    public class CreateSchemaTaskRequest : ApiRequest
    {
        public string Name { get; set; }

        [JsonIgnore]
        public Guid SchemaId { get; set; }
    }
}