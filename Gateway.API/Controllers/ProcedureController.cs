using System;
using System.Threading.Tasks;
using Gateway.API.Command.ScenarioManagement;
using Gateway.API.Query.ScenarioManagement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScenarioManagement.Domain;
using ScenarioManagement.Domain.Exceptions;

namespace Gateway.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Procedure")]
    public class ProcedureController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ProcedureController> _logger;


        /// <summary>
        /// The procedure queries
        /// </summary>
        private readonly IProcedureQueries _procedureQueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="procedureQueries">The procedure queries.</param>
        /// <exception cref="ArgumentNullException">procedureQueries
        /// or
        /// mediator
        /// or
        /// logger</exception>
        public ProcedureController(IMediator mediator, ILogger<ProcedureController> logger, IProcedureQueries procedureQueries)
        {
            this._procedureQueries = procedureQueries ?? throw new ArgumentNullException(nameof(procedureQueries));
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates the procedure.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProcedure([FromBody]CreateProcedureCommand command)
        {
            try
            {
                Procedure procedure = await this._mediator.Send(command);
                return Ok(procedure);
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets the procedure.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProcedure(Guid id)
        {
            ProcedureQueryDto procedure = await this._procedureQueries.GetProcedure(id);
            return Ok(procedure);
        }

        /// <summary>
        /// Adds the scenario.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{procedureId}/scenario")]
        public async Task<IActionResult> AddScenario(Guid procedureId, [FromBody] CreateScenarioCommand command)
        {
            try
            {
                command.ProcedureId = procedureId;
                Scenario scenario = await this._mediator.Send(command);
                return Ok(scenario);
            }
            catch (ScenarioManagementDomainException ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest(new { Reason = ex.Message });
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Adds the asset.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{procedureId}/scenario/{scenarioId}/asset")]
        public async Task<IActionResult> AddAsset(Guid procedureId, Guid scenarioId, [FromBody] AddScenarioAssetCommand command)
        {
            try
            {
                command.ProcedureId = procedureId;
                command.ScenarioId = scenarioId;
                ScenarioAsset asset = await this._mediator.Send(command);
                return Ok(asset);
            }
            catch (ScenarioManagementDomainException ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest(new { Reason = ex.Message });
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Removes the asset.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{procedureId}/scenario/{scenarioId}/asset/{tag}")]
        public async Task<IActionResult> RemoveAsset(Guid procedureId, Guid scenarioId, string tag)
        {
            try
            {
                RemoveAssetFromScenarioCommand command = new RemoveAssetFromScenarioCommand(procedureId, scenarioId, tag);
                await this._mediator.Send(command);
                return Ok();
            }
            catch (ScenarioManagementDomainException ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest(new { Reason = ex.Message });
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Removes the scenario.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{procedureId}/scenario/{scenarioId}")]
        public async Task<IActionResult> RemoveScenario(Guid procedureId, Guid scenarioId)
        {
            try
            {
                RemoveScenarioCommand command = new RemoveScenarioCommand(procedureId, scenarioId);
                await this._mediator.Send(command);
                return Ok();
            }
            catch (ScenarioManagementDomainException ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest(new { Reason = ex.Message });
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Removes the procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{procedureId}")]
        public async Task<IActionResult> RemoveProcedure(Guid procedureId)
        {
            try
            {
                RemoveProcedureCommand command = new RemoveProcedureCommand(procedureId);
                await this._mediator.Send(command);
                return Ok();
            }
            catch (ScenarioManagementDomainException ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest(new {Reason = ex.Message});
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }
    }
}