using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.ScenarioCreator
{
    /// <summary>
    /// A service used to manage schema entities.
    /// </summary>
    public interface ISchemaManager
    {
        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Schema GetSchema(Guid id);

        /// <summary>
        /// Creates the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        void CreateSchema(Schema schema);
    }
}
