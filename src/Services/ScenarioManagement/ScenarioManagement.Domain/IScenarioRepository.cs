﻿using System;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IRepository{ScenarioManagement.Domain.Scenario}" />
    public interface IScenarioRepository : IRepository<Scenario>
    {
        /// <summary>
        /// Adds the specified trial set.
        /// </summary>
        /// <param name="scenario">The trial set.</param>
        void Add(Scenario scenario);

        /// <summary>
        /// Updates the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        void Update(Scenario trialSet);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Scenario Get(Guid id);
    }
}