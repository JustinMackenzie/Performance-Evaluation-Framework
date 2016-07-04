using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implementation of the scenario repository interface that uses MongoDb to store scenarios.
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.MongoDbRepositories.MongoDbEntityRepository{ScenarioSim.Core.Entities.Scenario}" />
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
    }
}
