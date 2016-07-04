using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implementation of the actor repository interface that uses Mongo Db for storage.
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.MongoDbRepositories.MongoDbEntityRepository{ScenarioSim.Core.Entities.Actor}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IActorRepository" />
    public class MongoDbActorRepository : MongoDbEntityRepository<Actor>, IActorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbActorRepository"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public MongoDbActorRepository(string connectionStringOrName, string databaseName) : base(connectionStringOrName, databaseName)
        {
        }
    }
}
