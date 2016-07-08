using System;
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
        public IEnumerable<PerformanceViewModel> Get()
        {
            return manager.GetAllPerformances().Select(p => new PerformanceViewModel { Id = p.Id, PerformerId = p.PerformerId, ScenarioId = p.ScenarioId });
        }  

        // GET: api/Performance/5
        public PerformanceViewModel Get(Guid id)
        {
            ScenarioPerformance performance = manager.GetPerformance(id);

            return new PerformanceViewModel
            {
                Id = performance.Id,
                PerformerId = performance.PerformerId,
                ScenarioId = performance.ScenarioId
            };
        }

        // GET: api/Performance?schema=5
        [Route("api/Performance?schema={schemaId}")]
        public IEnumerable<PerformanceViewModel> GetBySchema(Guid schemaId)
        {
            Schema schema = schemaManager.GetSchema(schemaId);
            return manager.GetAllPerformances(schema).Select(p => new PerformanceViewModel { Id = p.Id, PerformerId = p.PerformerId, ScenarioId = p.ScenarioId });
        }

        // GET: api/Performance?performer=5
        [Route("api/Performance?performer={performerId}")]
        public IEnumerable<PerformanceViewModel> GetByPerformer(Guid performerId)
        {
            Performer performer = performerManager.GetPerformer(performerId);
            return manager.GetAllPerformances(performer).Select(p => new PerformanceViewModel { Id = p.Id, PerformerId = p.PerformerId, ScenarioId = p.ScenarioId });
        }

        // GET: api/PerformanceBySchema/5?performer=5
        [Route("api/Performance?schema={schemaId}&performer={performerId}")]
        public IEnumerable<PerformanceViewModel> GetBySchemaAndPerformer(Guid schemaId, Guid performerId)
        {
            Schema schema = schemaManager.GetSchema(schemaId);
            Performer performer = performerManager.GetPerformer(performerId);
            return manager.GetAllPerformances(schema, performer).Select(p => new PerformanceViewModel { Id = p.Id, PerformerId = p.PerformerId, ScenarioId = p.ScenarioId });
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
