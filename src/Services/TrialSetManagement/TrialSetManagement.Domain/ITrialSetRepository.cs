﻿using System;
using System.Collections.Generic;
using TrialSetManagement.Domain.SeedWork;

namespace TrialSetManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IRepository{ScenarioManagement.Domain.TrialSet}" />
    public interface ITrialSetRepository : IRepository<TrialSet>
    {
        /// <summary>
        /// Adds the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        void Add(TrialSet trialSet);

        /// <summary>
        /// Updates the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        void Update(TrialSet trialSet);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TrialSet Get(Guid id);

        /// <summary>
        /// Gets all trial sets.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TrialSet> GetAll();

        /// <summary>
        /// Deletes the trial set with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(Guid id);
    }
}