using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScenarioManagement.API.Application.Commands;
using ScenarioManagement.API.Application.Queries;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/TrialSet")]
    public class TrialSetController : Controller
    {
        /// <summary>
        /// The trial set queries
        /// </summary>
        private readonly ITrialSetQueries _trialSetQueries;

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetController" /> class.
        /// </summary>
        /// <param name="trialSetQueries">The trial set queries.</param>
        /// <param name="mediator">The mediator.</param>
        public TrialSetController(ITrialSetQueries trialSetQueries, IMediator mediator)
        {
            _trialSetQueries = trialSetQueries;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var trialSets = this._trialSetQueries.GetAllTrialSets();
            return Ok(trialSets);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var trial = this._trialSetQueries.GetTrialSetById(id);
            return Ok(trial);
        }

        /// <summary>
        /// Posts the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTrialSetCommand command)
        {
            try
            {
                TrialSet trialSet = await this._mediator.Send(command);
                return Ok(trialSet);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteTrialSetCommand command = new DeleteTrialSetCommand { TrialSetId = id };

            try
            {
                await this._mediator.Send(command);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Adds the scenario.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/scenario")]
        public async Task<IActionResult> AddScenario(Guid trialSetId, [FromBody] AddScenarioCommand command)
        {
            command.TrialSetId = trialSetId;

            try
            {
                await this._mediator.Send(command);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Removes the scenario.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{trialSetId}/scenario/{scenarioId}")]
        public async Task<IActionResult> RemoveScenario(Guid trialSetId, Guid scenarioId)
        {
            RemoveScenarioCommand command = new RemoveScenarioCommand(trialSetId, scenarioId);

            try
            {
                await this._mediator.Send(command);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates the name of the trial set.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/name")]
        public async Task<IActionResult> UpdateTrialSetName(Guid id, [FromBody] UpdateNameCommand command)
        {
            command.TrialSetId = id;

            try
            {
                await this._mediator.Send(command);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}