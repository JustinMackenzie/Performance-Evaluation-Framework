using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScenarioManagement.API.Application.Queries;

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
        /// The scenario queries
        /// </summary>
        private readonly IScenarioQueries _scenarioQueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioController"/> class.
        /// </summary>
        /// <param name="scenarioQueries">The scenario queries.</param>
        public ScenarioController(IScenarioQueries scenarioQueries)
        {
            _scenarioQueries = scenarioQueries;
        }

        /// <summary>
        /// Gets all scenarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllScenarios()
        {
            IEnumerable<ScenarioQueryDto> scenarios = await this._scenarioQueries.GetAllScenarios();
            return Ok(scenarios);
        }

        /// <summary>
        /// Gets the scenario.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{scenarioId}")]
        public async Task<IActionResult> GetScenario(Guid scenarioId)
        {
            ScenarioQueryDto scenario = await this._scenarioQueries.GetScenario(scenarioId);
            return Ok(scenario);
        }
    }
}