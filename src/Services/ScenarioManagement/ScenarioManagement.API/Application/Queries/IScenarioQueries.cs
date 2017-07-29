using System;
using System.Threading.Tasks;

namespace ScenarioManagement.API.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScenarioQueries
    {
        /// <summary>
        /// Gets the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ScenarioDto> GetScenario(Guid id);
    }
}
