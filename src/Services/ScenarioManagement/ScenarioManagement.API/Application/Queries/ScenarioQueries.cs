using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScenarioManagement.API.Repositories;

namespace ScenarioManagement.API.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.API.Application.Queries.IScenarioQueries" />
    public class ScenarioQueries : IScenarioQueries
    {
        /// <summary>
        /// The scenario query repository
        /// </summary>
        private readonly IScenarioQueryRepository _scenarioQueryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioQueries"/> class.
        /// </summary>
        /// <param name="scenarioQueryRepository">The scenario query repository.</param>
        public ScenarioQueries(IScenarioQueryRepository scenarioQueryRepository)
        {
            this._scenarioQueryRepository = scenarioQueryRepository;
        }

        /// <summary>
        /// Gets the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<ScenarioQueryDto> GetScenario(Guid id)
        {
            return this._scenarioQueryRepository.Get(id);
        }

        /// <summary>
        /// Gets all scenarios.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ScenarioQueryDto>> GetAllScenarios()
        {
            return this._scenarioQueryRepository.GetAll();
        }
    }
}