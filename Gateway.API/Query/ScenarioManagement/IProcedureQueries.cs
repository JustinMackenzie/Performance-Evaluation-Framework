using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.API.Query.ScenarioManagement
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

        /// <summary>
        /// Gets the procedure by scenario identifier.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <returns></returns>
        Task<ProcedureQueryDto> GetProcedureByScenarioId(Guid scenarioId);
    }
}
