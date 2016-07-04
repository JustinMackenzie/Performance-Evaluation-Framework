using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implemenation of the program repository interface that uses MongoDb to store and retrieve programs.
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.MongoDbRepositories.MongoDbEntityRepository{ScenarioSim.Core.Entities.Program}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IProgramRepository" />
    public class MongoDbProgramRepository : MongoDbEntityRepository<Program>, IProgramRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbProgramRepository"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public MongoDbProgramRepository(string connectionStringOrName, string databaseName) : base(connectionStringOrName, databaseName)
        {
        }
    }
}
