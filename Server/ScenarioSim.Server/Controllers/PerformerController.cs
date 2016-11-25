﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.PerformanceManagement;

namespace ScenarioSim.Server.Controllers
{
    /// <summary>
    /// The controller that receives performer related API calls.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Authorize]
    public class PerformerController : ApiController
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IPerformerManager manager;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformerController" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="logger">The logger.</param>
        public PerformerController(IPerformerManager manager, ILogger logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        // GET: api/Performer
        /// <summary>
        /// Gets all performers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Performer> Get()
        {
            try
            {
                return manager.GetAllPerformers();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        // GET: api/Performer/5
        /// <summary>
        /// Gets the performer with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Performer Get(Guid id)
        {
            try
            {
                return manager.GetPerformer(id);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}