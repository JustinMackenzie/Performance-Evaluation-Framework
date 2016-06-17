using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// Used to retrieve and store programs.
    /// </summary>
    public interface IProgramRepository
    {
        /// <summary>
        /// Gets all programs.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Program> GetAll();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Program Get(Guid id);

        /// <summary>
        /// Saves the specified program.
        /// </summary>
        /// <param name="program">The program.</param>
        void Save(Program program);

    }
}
