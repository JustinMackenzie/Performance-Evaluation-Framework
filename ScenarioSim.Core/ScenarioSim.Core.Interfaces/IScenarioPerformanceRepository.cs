using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
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

        /// <summary>
        /// Gets the scenario performances by schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <returns></returns>
        IEnumerable<ScenarioPerformance> GetBySchema(Schema schema);


    }
}
