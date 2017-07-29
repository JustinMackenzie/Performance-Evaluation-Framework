using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrialSetManagement.API.Application.Queries;

namespace TrialSetManagement.API.Infrastructure.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TrialSetManagement.API.Infrastructure.Services.ISchemaManagementService" />
    public class SchemaManagementService : ISchemaManagementService
    {
        /// <summary>
        /// The base URL
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaManagementService"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public SchemaManagementService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Gets the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ScenarioQueryDto> GetScenario(Guid id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{this._baseUrl}/api/scenario/{id}");
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ScenarioQueryDto>(content);
            }
        }
    }
}
