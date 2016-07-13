using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implementation of the performer repository interface that uses MongoDb to store performers.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Interfaces.IPerformerRepository" />
    /// <seealso cref="ScenarioSim.Infrastructure.MongoDbRepositories.MongoDbEntityRepository{ScenarioSim.Core.Entities.Performer}" />
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
