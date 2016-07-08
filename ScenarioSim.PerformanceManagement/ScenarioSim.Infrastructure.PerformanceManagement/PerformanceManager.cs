using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.PerformanceManagement;

namespace ScenarioSim.Infrastructure.PerformanceManagement
{
    /// <summary>
    /// An implementation of the performance manager service interface.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.PerformanceManagement.IPerformanceManager" />
    public class PerformanceManager : IPerformanceManager
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IScenarioPerformanceRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceManager" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public PerformanceManager(ILogger logger, IScenarioPerformanceRepository repository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.logger = logger;
            this.repository = repository;
        }

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScenarioPerformance> GetAllPerformances()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public IEnumerable<ScenarioPerformance> GetAllPerformances(Schema schema)
        {
            if (schema == null)
                throw new ArgumentNullException(nameof(schema));

            try
            {
                return repository.GetBySchema(schema);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <param name="performer">The performer.</param>
        /// <returns></returns>
        public IEnumerable<ScenarioPerformance> GetAllPerformances(Performer performer)
        {
            if (performer == null)
                throw new ArgumentNullException(nameof(performer));

            try
            {
                return repository.GetAll().Where(p => p.PerformerId == performer.Id);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all performances by performer.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="performer">The performer.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public IEnumerable<ScenarioPerformance> GetAllPerformances(Schema schema, Performer performer)
        {
            if (schema == null)
                throw new ArgumentNullException(nameof(schema));
            if (performer == null)
                throw new ArgumentNullException(nameof(performer));

            try
            {
                return GetAllPerformances(schema).Where(p => p.PerformerId == performer.Id);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Adds the performance.
        /// </summary>
        /// <param name="performance">The performance.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void AddPerformance(ScenarioPerformance performance)
        {
            if (performance == null)
                throw new ArgumentNullException(nameof(performance));

            try
            {
                repository.Save(performance);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        public ScenarioPerformance GetPerformance(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
