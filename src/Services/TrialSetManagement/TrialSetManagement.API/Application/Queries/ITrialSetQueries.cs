using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<IEnumerable<TrialSetQueryDto>> GetAllTrialSets();

        /// <summary>
        /// Gets the trial set by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TrialSetQueryDto> GetTrialSetById(Guid id);
    }
}
