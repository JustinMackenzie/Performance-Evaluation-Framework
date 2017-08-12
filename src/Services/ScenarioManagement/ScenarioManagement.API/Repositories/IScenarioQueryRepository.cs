using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScenarioManagement.API.Application.Queries;

namespace ScenarioManagement.API.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScenarioQueryRepository
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ScenarioQueryDto> Get(Guid id);

        /// <summary>
        /// Adds the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        Task Add(ScenarioQueryDto scenario);

        /// <summary>
        /// Updates the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        Task Update(ScenarioQueryDto scenario);

        /// <summary>
        /// Removes the scenario with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Remove(Guid id);

        /// <summary>
        /// Gets all the scenarios.
        /// </summary>
        /// <returns>A collection of all scenarios.</returns>
        Task<IEnumerable<ScenarioQueryDto>> GetAll();
    }
}