using System.Collections.Generic;
using System.Net.Http;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.HttpClientRepositories
{
    public class HttpClientScenarioPerformanceRepository : HttpClientEntityRepository<ScenarioPerformance>, IScenarioPerformanceRepository
    {
        /// <summary>
        /// Gets the scenario performances by scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        public IEnumerable<ScenarioPerformance> GetByScenario(Scenario scenario)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetAsync($"{BaseUrl}/api/ScenarioPerformances?scenarioId={scenario.Id}");
                string result = task.Result.Content.ReadAsStringAsync().Result;
                return JsonNetSerializer.JsonNetSerializer.DeserializeObject<IEnumerable<ScenarioPerformance>>(result);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientScenarioPerformanceRepository"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public HttpClientScenarioPerformanceRepository(string baseUrl) : base(baseUrl)
        {
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        /// <value>
        /// The name of the resource.
        /// </value>
        protected override string ResourceName => "performance";
    }
}
