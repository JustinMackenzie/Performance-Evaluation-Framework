using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Infrastructure.ScenarioCreator
{
    /// <summary>
    /// Implementation of the scenario manager service.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.ScenarioCreator.IScenarioManager" />
    public class ScenarioManager : IScenarioManager
    {
        private readonly ILogger logger;
        private readonly IScenarioRepository repository;

        public ScenarioManager(ILogger logger, IScenarioRepository repository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.logger = logger;
            this.repository = repository;
        }

        /// <summary>
        /// Gets all scenarios.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Scenario> GetAllScenarios()
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
        /// Gets the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Scenario GetScenario(Guid id)
        {
            try
            {
                return repository.Get(id);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CreateScenario(Scenario scenario)
        {
            if (scenario == null)
                throw new ArgumentNullException(nameof(scenario));

            try
            {
                repository.Save(scenario);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="scenario">The scenario.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UpdateScenario(Guid id, Scenario scenario)
        {
            try
            {
                Scenario s = GetScenario(id);

                s.Name = scenario.Name;
                s.Description = scenario.Description;

                repository.Save(s);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the scenario.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteScenario(Guid id)
        {
            try
            {
                Scenario scenario = GetScenario(id);
                repository.Remove(scenario);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all scenarios by program.
        /// </summary>
        /// <param name="program">The program.</param>
        /// <returns></returns>
        public IEnumerable<Scenario> GetAllScenariosByProgram(Program program)
        {
            return repository.GetByScenarioIds(program.ScenarioIds);
        }
    }
}
