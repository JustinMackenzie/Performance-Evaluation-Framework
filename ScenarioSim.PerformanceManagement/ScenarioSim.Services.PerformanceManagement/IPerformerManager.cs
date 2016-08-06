using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.PerformanceManagement
{
    /// <summary>
    /// A service interface used to manage performers.
    /// </summary>
    public interface IPerformerManager
    {
        /// <summary>
        /// Gets the performer.
        /// </summary>
        /// <param name="performerId">The performer identifier.</param>
        /// <returns></returns>
        Performer GetPerformer(Guid performerId);

        /// <summary>
        /// Gets all performers.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Performer> GetAllPerformers();
    }
}
