using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.ScenarioCreator
{
    /// <summary>
    /// A service used to manage scenario entities.
    /// </summary>
    public interface IScenarioManager
    {
        /// <summary>
        /// Gets all the scenarios.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Scenario> GetAllScenarios();

        /// <summary>
        /// Gets the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Scenario GetScenario(Guid id);

        /// <summary>
        /// Creates the scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        void CreateScenario(Scenario scenario);

        /// <summary>
        /// Updates the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="scenario">The scenario.</param>
        void UpdateScenario(Guid id, Scenario scenario);

        /// <summary>
        /// Deletes the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteScenario(Guid id);
    }
}
