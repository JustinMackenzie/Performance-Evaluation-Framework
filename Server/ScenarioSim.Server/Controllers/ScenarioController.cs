using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.Mapping;
using ScenarioSim.Services.ScenarioCreator;
using Program = ScenarioSim.Core.Entities.Program;
using Scenario = ScenarioSim.Core.DataTransfer.Scenario;

namespace ScenarioSim.Server.Controllers
{
    /// <summary>
    /// The Api controller that receives all scenario related calls.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors("http://localhost:45723", "*", "*")]
    [Authorize]
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
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="programManager">The program manager.</param>
        /// <param name="mapper">The mapper.</param>
        public ScenarioController(ILogger logger, IScenarioManager manager,
            IProgramManager programManager, IMapper mapper)
        {
            this.logger = logger;
            this.manager = manager;
            this.programManager = programManager;
            this.mapper = mapper;
        }

        // GET: api/Scenario
        /// <summary>
        /// Gets the scenarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Scenario> Get()
        {
            try
            {
                return manager.GetAllScenarios().Select(mapper.Map<Core.Entities.Scenario, Scenario>).ToList();
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
        public Scenario Get(Guid id)
        {
            try
            {
                Core.Entities.Scenario scenario = manager.GetScenario(id);
                return mapper.Map<Core.Entities.Scenario, Scenario>(scenario);
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
        [Authorize(Roles = "Scenario Author, Administrator")]
        public void Post(Scenario model)
        {
            try
            {
                Core.Entities.Scenario scenario = mapper.Map<Scenario, Core.Entities.Scenario>(model);
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
        [Authorize(Roles = "Scenario Author, Administrator")]
        public void Put(Guid id, Scenario model)
        {
            Core.Entities.Scenario scenario = new Core.Entities.Scenario
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
        [Authorize(Roles = "Scenario Author, Administrator")]
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
        public IEnumerable<Scenario> GetScenariosByProgram(Guid programId)
        {
            Program program = programManager.GetProgram(programId);
            return manager.GetAllScenariosByProgram(program).Select(mapper.Map<Core.Entities.Scenario, Scenario>);
        }
    }
}
