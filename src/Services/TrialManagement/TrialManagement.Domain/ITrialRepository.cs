using System;
using TrialManagement.Domain.SeedWork;

namespace TrialManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TrialManagement.Domain.SeedWork.IRepository{TrialManagement.Domain.Trial}" />
    public interface ITrialRepository : IRepository<Trial>
    {
        /// <summary>
        /// Gets the trial with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Trial Get(Guid id);

        /// <summary>
        /// Adds the specified trial.
        /// </summary>
        /// <param name="trial">The trial.</param>
        void Add(Trial trial);
    }
}
