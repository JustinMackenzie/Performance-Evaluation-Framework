using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScenarioManagement.API.Application.Commands;
using ScenarioManagement.API.Application.Queries;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/TrialSet")]
    public class TrialSetController : Controller
    {
        private readonly ITrialSetQueries _trialSetQueries;

        private readonly IMediator _mediator;

        public TrialSetController(ITrialSetQueries trialSetQueries, IMediator mediator)
        {
            _trialSetQueries = trialSetQueries;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var trialSets = this._trialSetQueries.GetAllTrialSets();
            return Ok(trialSets);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var trial = this._trialSetQueries.GetTrialSetById(id);
            return Ok(trial);
        }

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
    }
}