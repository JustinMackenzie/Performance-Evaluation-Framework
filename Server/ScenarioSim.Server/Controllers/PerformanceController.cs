using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ScenarioSim.Core.Entities;
using ScenarioSim.Server.Models;
using ScenarioSim.Services.PerformanceManagement;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Server.Controllers
{
    public class PerformanceController : ApiController
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IPerformanceManager manager;

        /// <summary>
        /// The schema manager
        /// </summary>
        private readonly ISchemaManager schemaManager;

        /// <summary>
        /// The performer manager
        /// </summary>
        private readonly IPerformerManager performerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceController" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="schemaManager">The schema manager.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public PerformanceController(IPerformanceManager manager, ISchemaManager schemaManager, IPerformerManager performerManager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));
            if (schemaManager == null)
                throw new ArgumentNullException(nameof(schemaManager));
            if (performerManager == null) 
                throw new ArgumentNullException(nameof(performerManager));

            this.manager = manager;
            this.schemaManager = schemaManager;
            this.performerManager = performerManager;
        }

        // GET: api/Performance
        public IEnumerable<ScenarioPerformance> Get()
        {
            return manager.GetAllPerformances();
        }  

        // GET: api/Performance/5
        public PerformanceViewModel Get(Guid id)
        {
            ScenarioPerformance performance = manager.GetPerformance(id);

            return new PerformanceViewModel
            {
                Id = performance.Id,
                PerformerId = performance.PerformerId
            };
        }

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
        public void Post(ScenarioPerformance performance)
        {
            manager.AddPerformance(performance);
        }

        // PUT: api/Performance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Performance/5
        public void Delete(int id)
        {
        }
    }
}
