using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.API.Query.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IProcedureQueries" />
    public class ProcedureQueries : IProcedureQueries
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IProcedureQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureQueries"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ProcedureQueries(IProcedureQueryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Gets the procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        public async Task<ProcedureQueryDto> GetProcedure(Guid procedureId)
        {
            return await this._repository.Get(procedureId);
        }

        /// <summary>
        /// Gets the procedures.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProcedureQueryDto>> GetProcedures()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Gets the procedure by scenario identifier.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <returns></returns>
        public async Task<ProcedureQueryDto> GetProcedureByScenarioId(Guid scenarioId)
        {
            IEnumerable<ProcedureQueryDto> procedures = await this.GetProcedures();
            return procedures.FirstOrDefault(p => p.Scenarios.Select(s => s.Id).Contains(scenarioId));
        }
    }
}