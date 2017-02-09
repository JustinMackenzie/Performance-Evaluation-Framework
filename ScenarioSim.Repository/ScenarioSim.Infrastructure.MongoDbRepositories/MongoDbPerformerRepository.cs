using ScenarioSim.Performance.Entities;
using ScenarioSim.Performance.Repositories;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implementation of the performer repository interface that uses MongoDb to store performers.
    /// </summary>
    /// <seealso cref="IPerformerRepository" />
    /// <seealso cref="Performer" />
    public class MongoDbPerformerRepository : MongoDbEntityRepository<Performer>, IPerformerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbPerformerRepository"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public MongoDbPerformerRepository(string connectionStringOrName, string databaseName) : base(connectionStringOrName, databaseName)
        {
        }
    }
}
