using System;
using System.Threading.Tasks;

namespace PerformanceEvaluation.API.IntegrationEvents.EventHandlers
{
    public interface IScenarioService
    {
        /// <summary>
        /// Gets the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Scenario> GetScenario(Guid id);
    }
}