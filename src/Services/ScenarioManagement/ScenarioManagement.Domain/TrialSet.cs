using System;
using System.Collections.Generic;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.Entity" />
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IAggregateRoot" />
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
        /// <param name="scenario">The scenario.</param>
        public void AddScenario(Scenario scenario)
        {
            if (scenario == null)
                throw new ArgumentNullException(nameof(scenario));

            this._scenarioIds.Add(scenario.Id);
        }
    }
}
