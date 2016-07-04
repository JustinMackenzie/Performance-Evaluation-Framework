using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.ScenarioCreator
{
    /// <summary>
    /// A service used to manage program entities.
    /// </summary>
    public interface IProgramManager
    {
        /// <summary>
        /// Gets all the programs.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Program> GetAllPrograms();

        /// <summary>
        /// Gets the program.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Program GetProgram(Guid id);

        /// <summary>
        /// Creates the program.
        /// </summary>
        /// <param name="program">The program.</param>
        void CreateProgram(Program program);

        /// <summary>
        /// Updates the program.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="program">The program.</param>
        void UpdateProgram(Guid id, Program program);

        /// <summary>
        /// Deletes the program.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteProgram(Guid id);
    }
}
