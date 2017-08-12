using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioManagement.Domain.Exceptions;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.Entity" />
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IAggregateRoot" />
    public class Procedure : Entity, IAggregateRoot
    {
        /// <summary>
        /// The scenarios
        /// </summary>
        private readonly List<Scenario> _scenarios;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the scenarios.
        /// </summary>
        /// <value>
        /// The scenarios.
        /// </value>
        public IReadOnlyList<Scenario> Scenarios => this._scenarios.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Procedure"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Procedure(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The procedure name cannot be null or empty.", nameof(name));
            }

            this.Name = name;
            this._scenarios = new List<Scenario>();
        }

        /// <summary>
        /// Adds the scenario.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The created scenario.</returns>
        public Scenario AddScenario(string name)
        {
            Scenario scenario = new Scenario(name);
            this._scenarios.Add(scenario);
            return scenario;
        }

        /// <summary>
        /// Removes the scenario.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        public void RemoveScenario(Guid scenarioId)
        {
            Scenario scenario = this._scenarios.FirstOrDefault(s => s.Id == scenarioId);

            if (scenario == null)
            {
                throw new ScenarioManagementDomainException("The scenario with the given identifier does not exist in this procedure.");    
            }

            this._scenarios.Remove(scenario);
        }

        /// <summary>
        /// Adds the scenario asset.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        /// <exception cref="ScenarioManagementDomainException">The scenario with the given identifier does not exist in this procedure.</exception>
        public ScenarioAsset AddScenarioAsset(Guid scenarioId, string tag, Vector position, Vector rotation,
            Vector scale)
        {
            Scenario scenario = this._scenarios.FirstOrDefault(s => s.Id == scenarioId);

            if (scenario == null)
            {
                throw new ScenarioManagementDomainException("The scenario with the given identifier does not exist in this procedure.");
            }

            return scenario.AddAsset(tag, position, rotation, scale);
        }

        /// <summary>
        /// Removes the scenario asset.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <exception cref="ScenarioManagementDomainException">The scenario with the given identifier does not exist in this procedure.</exception>
        public void RemoveScenarioAsset(Guid scenarioId, string tag)
        {
            Scenario scenario = this._scenarios.FirstOrDefault(s => s.Id == scenarioId);

            if (scenario == null)
            {
                throw new ScenarioManagementDomainException("The scenario with the given identifier does not exist in this procedure.");
            }

            scenario.RemoveAsset(tag);
        }
    }
}
