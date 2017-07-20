using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TrialSetManagement.Domain;

namespace TrialSetManagement.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Infrastructure.Repository{ScenarioManagement.Domain.Scenario}" />
    /// <seealso cref="IScenarioRepository" />
    public class ScenarioRepository : Repository<Scenario>, IScenarioRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioRepository" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public ScenarioRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <value>
        /// The name of the collection.
        /// </value>
        protected override string CollectionName => "Scenario";

        /// <summary>
        /// Adds the specified trial set.
        /// </summary>
        /// <param name="scenario">The trial set.</param>
        public void Add(Scenario scenario)
        {
            this.Collection.InsertOne(scenario);
        }

        /// <summary>
        /// Updates the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        public void Update(Scenario scenario)
        {
            this.Collection.ReplaceOne(s => s.Id == scenario.Id, scenario);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Scenario Get(Guid id)
        {
            return this.Collection.Find(s => s.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets the scenarios.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public IEnumerable<Scenario> GetScenarios(IList<Guid> ids)
        {
            List<Scenario> scenarios = this.Collection.Find(s => ids.Contains(s.Id))
                .ToList();
            return scenarios.OrderBy(s => ids.IndexOf(s.Id));
        }
    }
}
