using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Infrastructure.ScenarioCreator
{
    /// <summary>
    /// Represents the implementation of the schema manager service interface.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.ScenarioCreator.ISchemaManager" />
    public class SchemaManager : ISchemaManager
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISchemaRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaManager"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The unit of work.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public SchemaManager(ILogger logger, ISchemaRepository repository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.logger = logger;
            this.repository = repository;
        }

        /// <summary>
        /// Gets all the schemas.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Schema> GetAllSchemas()
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
        /// Gets the schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Schema GetSchema(Guid id)
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
        /// Creates the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateSchema(Schema schema)
        {
            if (schema == null)
                throw new ArgumentNullException(nameof(schema));

            try
            {
                repository.Save(schema);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="schema">The schema.</param>
        public void UpdateSchema(Guid id, Schema schema)
        {
            try
            {
                Schema s = GetSchema(id);

                s.Name = schema.Name;
                s.Task = schema.Task;
                
                repository.Save(s);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteSchema(Guid id)
        {
            try
            {
                Schema schema = GetSchema(id);
                repository.Remove(schema);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}
