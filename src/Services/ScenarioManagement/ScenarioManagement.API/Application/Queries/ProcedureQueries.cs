using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.API.Repositories;

namespace ScenarioManagement.API.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.API.Application.Queries.IProcedureQueries" />
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
    }
}