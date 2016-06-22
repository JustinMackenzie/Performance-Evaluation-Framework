using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.ScenarioCreator
{
    /// <summary>
    /// A service used to manage schema entities.
    /// </summary>
    public interface ISchemaManager
    {
        /// <summary>
        /// Gets all the schemas.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Schema> GetAllSchemas();

        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Schema GetSchema(int id);

        /// <summary>
        /// Creates the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        void CreateSchema(Schema schema);

        /// <summary>
        /// Updates the schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="schema">The schema.</param>
        void UpdateSchema(int id, Schema schema);

        /// <summary>
        /// Deletes the schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteSchema(int id);
    }
}
