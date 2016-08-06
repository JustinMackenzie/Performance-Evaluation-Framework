using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.PerformanceManagement;

namespace ScenarioSim.Infrastructure.PerformanceManagement
{
    /// <summary>
    /// An implementation of the performer manager service interface.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.PerformanceManagement.IPerformerManager" />
    public class PerformerManager : IPerformerManager
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IPerformerRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformerManager" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public PerformerManager(ILogger logger, IPerformerRepository repository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.logger = logger;
            this.repository = repository;
        }

        /// <summary>
        /// Gets the performer.
        /// </summary>
        /// <param name="performerId">The performer identifier.</param>
        /// <returns></returns>
        public Performer GetPerformer(Guid performerId)
        {
            try
            {
                return repository.Get(performerId);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        public IEnumerable<Performer> GetAllPerformers()
        {
            return repository.GetAll();
        }
    }
}
