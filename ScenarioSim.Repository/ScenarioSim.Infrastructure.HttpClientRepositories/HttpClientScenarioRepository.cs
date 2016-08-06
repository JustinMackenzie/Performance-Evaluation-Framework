using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.HttpClientRepositories
{
    public class HttpClientScenarioRepository : HttpClientEntityRepository<Scenario>, IScenarioRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientScenarioRepository"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public HttpClientScenarioRepository(string baseUrl) : base(baseUrl)
        {
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        /// <value>
        /// The name of the resource.
        /// </value>
        protected override string ResourceName => "scenario";

        /// <summary>
        /// Gets the by scenario ids.
        /// </summary>
        /// <param name="scenarioIds">The scenario ids.</param>
        /// <returns></returns>
        public IEnumerable<Scenario> GetByScenarioIds(IList<Guid> scenarioIds)
        {
            return GetAll().Where(s => scenarioIds.Contains(s.Id));
        }
    }
}
