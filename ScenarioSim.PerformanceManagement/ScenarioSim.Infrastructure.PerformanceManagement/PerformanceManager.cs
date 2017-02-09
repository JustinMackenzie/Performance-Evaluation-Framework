using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Performance.Repositories;
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
        /// The repository
        /// </summary>
        private readonly IScenarioRepository scenarioRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceManager" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="scenarioRepository">The scenario repository.</param>
        public PerformanceManager(ILogger logger, IScenarioPerformanceRepository repository, IScenarioRepository scenarioRepository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            if (scenarioRepository == null)
                throw new ArgumentNullException(nameof(scenarioRepository));

            this.logger = logger;
            this.repository = repository;
            this.scenarioRepository = scenarioRepository;
        }

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScenarioPerformance> GetAllPerformances()
        {
            return repository.GetAll();
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

            IEnumerable<Scenario> scenarios = scenarioRepository.GetAll().Where(s => s.SchemaId == schema.Id);
            return scenarios.SelectMany(s => repository.GetByScenario(s));
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

            return repository.GetAll().Where(p => p.PerformerId == performer.Id);
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

            return GetAllPerformances(schema).Where(p => p.PerformerId == performer.Id);
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

            repository.Save(performance);
        }

        public ScenarioPerformance GetPerformance(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeletePerformance(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("The identifier cannot be empty.", nameof(id));

            ScenarioPerformance performance = GetPerformance(id);

            if (performance == null)
                throw new InvalidOperationException("A scenario performance with the given identifier does not exist.");

            repository.Remove(performance);
        }
    }
}
