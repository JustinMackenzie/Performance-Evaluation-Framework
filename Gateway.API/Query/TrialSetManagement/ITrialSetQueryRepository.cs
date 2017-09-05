using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.API.Query.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITrialSetQueryRepository
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TrialSetQueryDto>> GetAll();

        /// <summary>
        /// Gets the trial set.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TrialSetQueryDto> GetTrialSet(Guid id);

        /// <summary>
        /// Updates the specified trial set query.
        /// </summary>
        /// <param name="trialSetQuery">The trial set query.</param>
        /// <returns></returns>
        Task Update(TrialSetQueryDto trialSetQuery);

        /// <summary>
        /// Adds the specified trial set query.
        /// </summary>
        /// <param name="trialSetQuery">The trial set query.</param>
        /// <returns></returns>
        Task Add(TrialSetQueryDto trialSetQuery);
    }
}