using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScenarioManagement.API.Application.Commands;
using ScenarioManagement.Domain;

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
        /// Initializes a new instance of the <see cref="ScenarioController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ScenarioController(IMediator mediator)
        {
            _mediator = mediator;
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
            catch
            {
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
            catch
            {
                return BadRequest();
            }
        }
    }
}