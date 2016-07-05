using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ScenarioSim.Core.Entities;
using ScenarioSim.ScenarioCreatorApi.Models;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.ScenarioCreatorApi.Controllers
{
    /// <summary>
    /// The Api controller that receives all scenario related calls.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors("http://localhost:45723", "*", "*")]
    public class ScenarioController : ApiController
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IScenarioManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public ScenarioController(IScenarioManager manager)
        {
            this.manager = manager;
        }

        // GET: api/Scenario
        /// <summary>
        /// Gets the scenarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScenarioViewModel> Get()
        {
            return
                manager.GetAllScenarios()
                    .Select(s => new ScenarioViewModel {Id = s.Id, Name = s.Name, Description = s.Description});
        }

        // GET: api/Scenario/5
        /// <summary>
        /// Gets the specified scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ScenarioDetailsViewModel Get(Guid id)
        {
            Scenario scenario = manager.GetScenario(id);

            return new ScenarioDetailsViewModel
            {
                Id = scenario.Id,
                Name = scenario.Name,
                Description = scenario.Description
            };
        }

        // POST: api/Scenario
        /// <summary>
        /// Posts the specified scenario.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Post(CreateScenarioViewModel model)
        {
            Scenario scenario = new Scenario
            {
                Name = model.Name,
                Description = model.Description
            };

            manager.CreateScenario(scenario);
        }

        // PUT: api/Scenario/5
        /// <summary>
        /// Puts the specified scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        public void Put(Guid id, EditScenarioViewModel model)
        {
            Scenario scenario = new Scenario
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            manager.UpdateScenario(id, scenario);
        }

        // DELETE: api/Scenario/5
        /// <summary>
        /// Deletes the specified scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            manager.DeleteScenario(id);
        }
    }
}
