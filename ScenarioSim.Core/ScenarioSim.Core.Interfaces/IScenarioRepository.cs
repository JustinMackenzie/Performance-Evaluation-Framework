using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// An interface used to store and retrieve scenarios.
    /// </summary>
    /// <seealso cref="Scenario" />
    public interface IScenarioRepository : IEntityRepository<Scenario>
    {
        /// <summary>
        /// Gets the by scenario ids.
        /// </summary>
        /// <param name="scenarioIds">The scenario ids.</param>
        /// <returns></returns>
        IEnumerable<Scenario> GetByScenarioIds(IList<Guid> scenarioIds);
    }
}
