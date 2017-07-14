using System;
using System.Collections.Generic;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITrialSetQueries
    {
        /// <summary>
        /// Gets all trial sets.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TrialSet> GetAllTrialSets();

        /// <summary>
        /// Gets the trial set by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TrialSetDto GetTrialSetById(Guid id);
    }
}
