using System;
using System.Threading.Tasks;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IRepository{ScenarioManagement.Domain.Procedure}" />
    public interface IProcedureRepository : IRepository<Procedure>
    {
        /// <summary>
        /// Adds the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        Task Add(Procedure procedure);

        /// <summary>
        /// Updates the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        Task Update(Procedure procedure);

        /// <summary>
        /// Deletes the specified procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        Task Delete(Guid procedureId);

        /// <summary>
        /// Gets the specified procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        Task<Procedure> Get(Guid procedureId);
    }
}
