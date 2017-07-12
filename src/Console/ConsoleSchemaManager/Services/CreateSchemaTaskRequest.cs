using System;
using ConsoleSchemaManager.Services;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.CommandHandlers
{
    public class CreateSchemaTaskRequest : ApiRequest
    {
        public string Name { get; set; }

        [JsonIgnore]
        public Guid SchemaId { get; set; }
    }
}