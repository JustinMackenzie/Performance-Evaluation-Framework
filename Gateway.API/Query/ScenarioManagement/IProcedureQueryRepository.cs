using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.API.Query.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProcedureQueryRepository
    {
        /// <summary>
        /// Adds the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        Task Add(ProcedureQueryDto procedure);

        /// <summary>
        /// Gets the specified procedure identifier.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        Task<ProcedureQueryDto> Get(Guid procedureId);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProcedureQueryDto>> GetAll();

        /// <summary>
        /// Deletes the specified procedure identifier.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        Task Delete(Guid procedureId);

        /// <summary>
        /// Updates the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        Task Update(ProcedureQueryDto procedure);
    }
}