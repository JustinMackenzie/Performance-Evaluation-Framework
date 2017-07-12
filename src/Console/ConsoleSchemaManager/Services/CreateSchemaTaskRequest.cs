using System;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Services.ApiRequest" />
    public class CreateSchemaTaskRequest : ApiRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        [JsonIgnore]
        public Guid SchemaId { get; set; }
    }
}