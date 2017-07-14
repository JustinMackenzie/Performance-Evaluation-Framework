using System;
using Microsoft.AspNetCore.Mvc;
using ScenarioManagement.API.Application.Queries;

namespace ScenarioManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/TrialSet")]
    public class TrialSetController : Controller
    {
        private readonly ITrialSetQueries _trialSetQueries;

        public TrialSetController(ITrialSetQueries trialSetQueries)
        {
            _trialSetQueries = trialSetQueries;
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
    }
}