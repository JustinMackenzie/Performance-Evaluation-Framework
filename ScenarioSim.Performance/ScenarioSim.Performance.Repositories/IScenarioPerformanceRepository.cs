using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Performance.Entities;

namespace ScenarioSim.Performance.Repositories
{
    /// <summary>
    /// Used to store and retrieve scenario performances.
    /// </summary>
    public interface IScenarioPerformanceRepository : IEntityRepository<ScenarioPerformance>
    {
        /// <summary>
        /// Gets the scenario performances by scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        IEnumerable<ScenarioPerformance> GetByScenario(Scenario scenario);
    }
}
