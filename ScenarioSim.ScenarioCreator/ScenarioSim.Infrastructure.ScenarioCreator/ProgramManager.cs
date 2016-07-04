using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Infrastructure.ScenarioCreator
{
    /// <summary>
    /// Implementation of the program manager service.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.ScenarioCreator.IProgramManager" />
    public class ProgramManager : IProgramManager
    {
        private readonly ILogger logger;
        private readonly IProgramRepository repository;

        public ProgramManager(ILogger logger, IProgramRepository repository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.logger = logger;
            this.repository = repository;
        }

        /// <summary>
        /// Gets all programs.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Program> GetAllPrograms()
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
        /// Gets the program.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Program GetProgram(Guid id)
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
        /// Creates the program.
        /// </summary>
        /// <param name="program">The program.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CreateProgram(Program program)
        {
            if (program == null)
                throw new ArgumentNullException(nameof(program));

            try
            {
                repository.Save(program);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the program.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="program">The program.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UpdateProgram(Guid id, Program program)
        {
            try
            {
                Program a = GetProgram(id);

                a.Name = program.Name;
                a.Description = program.Description;

                repository.Save(a);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Removes the program.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void DeleteProgram(Guid id)
        {
            try
            {
                Program program = GetProgram(id);
                repository.Remove(program);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}
