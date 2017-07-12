using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ApiRequest
    {
        /// <summary>
        /// Gets or sets the server URL.
        /// </summary>
        /// <value>
        /// The server URL.
        /// </value>
        [JsonIgnore]
        public string ServerUrl { get; set; }
    }
}