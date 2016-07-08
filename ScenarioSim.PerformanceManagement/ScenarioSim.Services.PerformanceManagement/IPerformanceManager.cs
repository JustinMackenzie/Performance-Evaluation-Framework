using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.PerformanceManagement
{
    /// <summary>
    /// Service interface used to add and retrieve performances.
    /// </summary>
    public interface IPerformanceManager
    {
        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ScenarioPerformance> GetAllPerformances();

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <returns></returns>
        IEnumerable<ScenarioPerformance> GetAllPerformances(Schema schema);

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <param name="performer">The performer.</param>
        /// <returns></returns>
        IEnumerable<ScenarioPerformance> GetAllPerformances(Performer performer);

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="performer">The performer.</param>
        /// <returns></returns>
        IEnumerable<ScenarioPerformance> GetAllPerformances(Schema schema, Performer performer);

        /// <summary>
        /// Adds the performance.
        /// </summary>
        /// <param name="performance">The performance.</param>
        void AddPerformance(ScenarioPerformance performance);

        /// <summary>
        /// Gets the performance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ScenarioPerformance GetPerformance(Guid id);
    }
}
