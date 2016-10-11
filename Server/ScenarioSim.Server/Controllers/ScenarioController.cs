using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using ScenarioSim.Core.Entities;
using ScenarioSim.Server.Models;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Server.Controllers
{
    /// <summary>
    /// The Api controller that receives all scenario related calls.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors("http://localhost:45723", "*", "*")]
    public class ScenarioController : ApiController
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The manager
        /// </summary>
        private readonly IScenarioManager manager;

        /// <summary>
        /// The program manager
        /// </summary>
        private readonly IProgramManager programManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="programManager">The program manager.</param>
        public ScenarioController(ILogger logger, IScenarioManager manager,
            IProgramManager programManager)
        {
            this.logger = logger;
            this.manager = manager;
            this.programManager = programManager;
        }

        // GET: api/Scenario
        /// <summary>
        /// Gets the scenarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScenarioViewModel> Get()
        {
            try
            {
                return manager.GetAllScenarios().Select(Mapper.Map<Scenario, ScenarioViewModel>).ToList();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        // GET: api/Scenario/5
        /// <summary>
        /// Gets the specified scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ScenarioViewModel Get(Guid id)
        {
            try
            {
                Scenario scenario = manager.GetScenario(id);
                return Mapper.Map<Scenario, ScenarioViewModel>(scenario);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        // POST: api/Scenario
        /// <summary>
        /// Posts the specified scenario.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Post(ScenarioViewModel model)
        {
            try
            {
                Scenario scenario = Mapper.Map<ScenarioViewModel, Scenario>(model);
                manager.CreateScenario(scenario);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        // PUT: api/Scenario/5
        /// <summary>
        /// Puts the specified scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        public void Put(Guid id, ScenarioViewModel model)
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

        /// <summary>
        /// Gets the scenarios by program.
        /// </summary>
        /// <param name="programId">The program identifier.</param>
        [Route("api/GetScenariosByProgram/{programId}")]
        [HttpGet]
        public IEnumerable<ScenarioViewModel> GetScenariosByProgram(Guid programId)
        {
            Program program = programManager.GetProgram(programId);
            return manager.GetAllScenariosByProgram(program).Select(Mapper.Map<Scenario, ScenarioViewModel>);
        }
    }
}
