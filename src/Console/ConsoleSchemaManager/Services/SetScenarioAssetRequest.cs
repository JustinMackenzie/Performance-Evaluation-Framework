using System;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    public class SetScenarioAssetRequest : ApiRequest
    {
        [JsonIgnore]
        public Guid SchemaId { get; set; }

        [JsonIgnore]
        public Guid ScenarioId { get; set; }

        public Guid AssetId { get; set; }

        public VectorDto Position { get; set; }

        public VectorDto Rotation { get; set; }

        public VectorDto Scale { get; set; }
    }
}