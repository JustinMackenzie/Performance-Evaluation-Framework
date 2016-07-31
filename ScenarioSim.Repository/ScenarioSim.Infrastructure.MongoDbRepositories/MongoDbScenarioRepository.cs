using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implementation of the scenario repository interface that uses MongoDb to store scenarios.
    /// </summary>
    /// <seealso cref="Scenario" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IScenarioRepository" />
    public class MongoDbScenarioRepository : MongoDbEntityRepository<Scenario>, IScenarioRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbScenarioRepository"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public MongoDbScenarioRepository(string connectionStringOrName, string databaseName) : base(connectionStringOrName, databaseName)
        {
        }

        public override Scenario Get(Guid id)
        {
            Scenario scenario = base.Get(id);

            if (scenario == null)
                return null;

            IMongoCollection<Schema> schemas = Database.GetCollection<Schema>(typeof (Schema).Name);
            scenario.Schema = schemas.Find(s => s.Id == scenario.SchemaId).FirstOrDefault();

            return scenario;
        }

        public IEnumerable<Scenario> GetByScenarioIds(IList<Guid> scenarioIds)
        {
            return GetAll()
                .Where(s => scenarioIds.Contains(s.Id))
                .OrderBy(s => scenarioIds.IndexOf(s.Id));
        }
    }
}
