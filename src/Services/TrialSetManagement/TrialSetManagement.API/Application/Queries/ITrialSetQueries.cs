using System;
using System.Collections.Generic;
using TrialSetManagement.Domain;

namespace TrialSetManagement.API.Application.Queries
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
        IEnumerable<TrialSetQueryDto> GetAllTrialSets();

        /// <summary>
        /// Gets the trial set by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TrialSetQueryDto GetTrialSetById(Guid id);
    }
}
