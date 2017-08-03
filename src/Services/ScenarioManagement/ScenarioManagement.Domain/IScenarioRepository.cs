using System;
using System.Threading.Tasks;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IRepository{ScenarioManagement.Domain.Scenario}" />
    public interface IScenarioRepository : IRepository<Scenario>
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Scenario> Get(Guid id);

        /// <summary>
        /// Adds the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        Task Add(Scenario scenario);

        /// <summary>
        /// Updates the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        Task Update(Scenario scenario);


        /// <summary>
        /// Deletes the scenario with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}
