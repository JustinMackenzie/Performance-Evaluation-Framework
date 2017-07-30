using System;
using System.Threading.Tasks;
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
        /// Adds the specified trial.
        /// </summary>
        /// <param name="trial">The trial.</param>
        Task Add(Trial trial);
    }
}
