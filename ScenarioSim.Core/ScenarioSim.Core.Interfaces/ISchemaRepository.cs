using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISchemaRepository
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Schema> GetAll();

        /// <summary>
        /// Gets the specified unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        Schema Get(Guid guid);

        /// <summary>
        /// Saves the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        void Save(Schema schema);

        /// <summary>
        /// Removes the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        void Remove(Schema schema);
    }
}
