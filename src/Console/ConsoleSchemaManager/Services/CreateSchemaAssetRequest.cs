using System;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    public class CreateSchemaAssetRequest : ApiRequest
    {
        [JsonIgnore]
        public Guid SchemaId { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }
    }
}