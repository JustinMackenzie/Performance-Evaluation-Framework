using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// The mongodb implementation of the schema repository interface.
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.MongoDbRepositories.MongoDbEntityRepository{ScenarioSim.Core.Entities.Schema}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.ISchemaRepository" />
    public class MongoDbSchemaRepository : MongoDbEntityRepository<Schema>, ISchemaRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbSchemaRepository"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public MongoDbSchemaRepository(string connectionStringOrName, string databaseName) : base(connectionStringOrName, databaseName)
        {
        }
    }
}
