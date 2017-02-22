﻿using System;
using System.Collections.Generic;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Performance.Repositories;
using ScenarioSim.Services.PerformanceManagement;

namespace ScenarioSim.Infrastructure.PerformanceManagement
{
    /// <summary>
    /// An implementation of the performer manager service interface.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.PerformanceManagement.IPerformerManager" />
    public class PerformerManager : IPerformerManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IPerformerRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformerManager" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public PerformerManager(IPerformerRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        /// <summary>
        /// Gets the performer.
        /// </summary>
        /// <param name="performerId">The performer identifier.</param>
        /// <returns></returns>
        public Performer GetPerformer(Guid performerId)
        {
            return repository.Get(performerId);
        }

        /// <summary>
        /// Gets all performers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Performer> GetAllPerformers()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Adds the performer.
        /// </summary>
        /// <param name="performer">The performer.</param>
        public void AddPerformer(Performer performer)
        {
            repository.Save(performer);
        }
    }
}
