using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScenarioManagement.API.Application.Commands;
using ScenarioManagement.API.Application.Queries;
using ScenarioManagement.Domain;
using ScenarioManagement.Domain.Exceptions;

namespace ScenarioManagement.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Scenario")]
    public class ScenarioController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// The queries
        /// </summary>
        private readonly IScenarioQueries _queries;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ScenarioController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="queries">The queries.</param>
        public ScenarioController(IMediator mediator, IScenarioQueries queries, ILogger<ScenarioController> logger)
        {
            _mediator = mediator;
            _queries = queries;
            _logger = logger;
        }

        /// <summary>
        /// Gets all scenarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllScenarios()
        {
            try
            {
                IEnumerable<ScenarioDto> scenarios = await this._queries.GetAllScenarios();
                return Ok(scenarios);
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetScenario(Guid id)
        {
            try
            {
                ScenarioDto scenario = await this._queries.GetScenario(id);
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Adds the scenario.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddScenario([FromBody] CreateScenarioCommand command)
        {
            try
            {
                Scenario scenario = await this._mediator.Send(command);
                return Ok(scenario);
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
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/asset")]
        public async Task<IActionResult> AddAsset(Guid scenarioId, [FromBody] AddScenarioAssetCommand command)
        {
            try
            {
                command.ScenarioId = scenarioId;
                ScenarioAsset asset = await this._mediator.Send(command);
                return Ok(asset);
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{scenarioId}/asset/{tag}")]
        public async Task<IActionResult> RemoveAsset(Guid scenarioId, string tag)
        {
            try
            {
                RemoveAssetFromScenarioCommand command = new RemoveAssetFromScenarioCommand(scenarioId, tag);
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

        [HttpDelete]
        [Route("{scenarioId}")]
        public async Task<IActionResult> RemoveScenario(Guid scenarioId)
        {
            try
            {
                RemoveScenarioCommand command = new RemoveScenarioCommand(scenarioId);
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
    }
}