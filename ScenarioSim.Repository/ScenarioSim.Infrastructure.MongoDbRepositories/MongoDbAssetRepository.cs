using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implementation of the asset repository interface that uses MongoDb to store and retrieve assets.
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.MongoDbRepositories.MongoDbEntityRepository{ScenarioSim.Core.Entities.Asset}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IAssetRepository" />
    public class MongoDbAssetRepository : MongoDbEntityRepository<Asset>, IAssetRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbAssetRepository"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public MongoDbAssetRepository(string connectionStringOrName, string databaseName) : base(connectionStringOrName, databaseName)
        {
        }
    }
}
