using System;
using System.Collections.Generic;
using TrialSetManagement.Domain.SeedWork;

namespace TrialSetManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Entity" />
    /// <seealso cref="IAggregateRoot" />
    public class TrialSet : Entity, IAggregateRoot
    {
        /// <summary>
        /// The scenario ids
        /// </summary>
        private List<Guid> _scenarioIds;

        /// <summary>
        /// Gets the scenario ids.
        /// </summary>
        /// <value>
        /// The scenario ids.
        /// </value>
        public IReadOnlyList<Guid> ScenarioIds => this._scenarioIds;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSet"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public TrialSet(string name)
        {
            this.Name = name;
            this._scenarioIds = new List<Guid>();
        }

        /// <summary>
        /// Adds the scenario.
        /// </summary>
        /// <param name="scenarioId">The scenario.</param>
        public void AddScenario(Guid scenarioId)
        {
            if (scenarioId == null)
                throw new ArgumentNullException(nameof(scenarioId));

            this._scenarioIds.Add(scenarioId);
        }

        public void RemoveScenario(Guid scenarioId)
        {
            this._scenarioIds.Remove(scenarioId);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name cannot be null or empty.", nameof(name));

            this.Name = name;
        }
    }
}
