using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.PerformanceManagement;

namespace ScenarioSim.PerformanceManagementService.Controllers
{
    /// <summary>
    /// Allows access to and storage of performances.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Authorize]
    public class PerformanceController : ApiController
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The manager
        /// </summary>
        private readonly IPerformanceManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="manager">The manager.</param>
        public PerformanceController(ILogger logger, IPerformanceManager manager)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            this.logger = logger;
            this.manager = manager;
        }

        // GET: api/Performance
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScenarioPerformance> Get()
        {
            return manager.GetAllPerformances();
        }

        // GET: api/Performance/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ScenarioPerformance Get(Guid id)
        {
            ScenarioPerformance performance = manager.GetPerformance(id);

            return performance;
        }

        /// <summary>
        /// Gets the scenario performances based on the given filters.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="performerId">The performer identifier.</param>
        /// <returns></returns>
        [Route("api/ScenarioPerformances")]
        [HttpGet]
        public IEnumerable<ScenarioPerformance> ScenarioPerformances(Guid? schemaId = null, Guid? scenarioId = null,
            Guid? performerId = null)
        {
            IEnumerable<ScenarioPerformance> performances = manager.GetAllPerformances();

            if (schemaId.HasValue)
                performances = performances.Where(p => p.Scenario.SchemaId == schemaId.Value);

            if (scenarioId.HasValue)
                performances = performances.Where(p => p.Scenario.Id == scenarioId.Value);

            if (performerId.HasValue)
                performances = performances.Where(p => p.PerformerId == performerId.Value);

            return performances;
        }

        // POST: api/Performance
        /// <summary>
        /// Stores the specified performance.
        /// </summary>
        /// <param name="performance">The performance.</param>
        [Authorize(Roles = "Performer")]
        public void Post(ScenarioPerformance performance)
        {
            try
            {
                manager.AddPerformance(performance);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        // DELETE: api/Performance/5
        /// <summary>
        /// Deletes the specified performance with the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [Authorize(Roles = "Evaluator, Administrator")]
        public void Delete(Guid id)
        {
            try
            {
                manager.DeletePerformance(id);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}
