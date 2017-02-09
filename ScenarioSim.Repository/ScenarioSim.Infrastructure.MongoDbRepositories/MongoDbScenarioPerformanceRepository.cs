using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Performance.Repositories;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// An implementation of the scenario performance repository that uses MongoDb to store scenario performances.
    /// </summary>
    /// <seealso cref="ScenarioPerformance" />
    /// <seealso cref="IScenarioPerformanceRepository" />
    public class MongoDbScenarioPerformanceRepository : MongoDbEntityRepository<ScenarioPerformance>, IScenarioPerformanceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbScenarioPerformanceRepository"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public MongoDbScenarioPerformanceRepository(string connectionStringOrName, string databaseName) : base(connectionStringOrName, databaseName)
        {
        }

        /// <summary>
        /// Gets the scenario performances by scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ScenarioPerformance> GetByScenario(Scenario scenario)
        {
            return GetAll().Where(p => p.Scenario.Id == scenario.Id);
        }
    }
}
