﻿using System;
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
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaManager"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public SchemaManager(ILogger logger, IUnitOfWork unitOfWork)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all the schemas.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Schema> GetAllSchemas()
        {
            try
            {
                return unitOfWork.SchemaRepository.GetAll();
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
        public Schema GetSchema(int id)
        {
            try
            {
                return unitOfWork.SchemaRepository.Get(id);
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
                unitOfWork.SchemaRepository.Save(schema);
                unitOfWork.Commit();
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
        public void UpdateSchema(int id, Schema schema)
        {
            try
            {
                Schema s = GetSchema(id);

                s.Name = schema.Name;
                s.Actors = schema.Actors;
                s.Task = schema.Task;
                s.Id = id;
                
                unitOfWork.SchemaRepository.Save(s);
                unitOfWork.Commit();
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
        public void DeleteSchema(int id)
        {
            try
            {
                Schema schema = GetSchema(id);
                unitOfWork.SchemaRepository.Remove(schema);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}
