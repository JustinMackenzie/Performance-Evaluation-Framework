using System;
using System.Collections.Generic;

namespace Simulator.Unity.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITrialSetManagementService
    {
        /// <summary>
        /// Gets the trial set by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TrialSet GetTrialSetById(Guid id);

        /// <summary>
        /// Gets all trial sets.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TrialSet> GetAllTrialSets();
    }
}
