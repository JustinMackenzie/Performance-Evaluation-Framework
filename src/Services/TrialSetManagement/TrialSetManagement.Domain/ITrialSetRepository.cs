using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrialSetManagement.Domain.SeedWork;

namespace TrialSetManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IRepository{ScenarioManagement.Domain.TrialSet}" />
    public interface ITrialSetRepository : IRepository<TrialSet>
    {
        /// <summary>
        /// Adds the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        Task Add(TrialSet trialSet);

        /// <summary>
        /// Updates the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        Task Update(TrialSet trialSet);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TrialSet> Get(Guid id);

        /// <summary>
        /// Deletes the trial set with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task Delete(Guid id);
    }
}
