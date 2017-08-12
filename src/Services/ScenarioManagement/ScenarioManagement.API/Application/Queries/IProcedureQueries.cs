using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScenarioManagement.API.IntegrationEvents.Events;

namespace ScenarioManagement.API.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProcedureQueries
    {
        /// <summary>
        /// Gets the procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        Task<ProcedureQueryDto> GetProcedure(Guid procedureId);

        /// <summary>
        /// Gets the procedures.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProcedureQueryDto>> GetProcedures();
    }
}
