using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ScenarioManagement.API.Application.Queries;

namespace ScenarioManagement.API.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ScenarioQueryRepository : IScenarioQueryRepository
    {
        /// <summary>
        /// The connection string name
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// The database name
        /// </summary>
        private readonly string _databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioQueryRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public ScenarioQueryRepository(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        private IMongoDatabase Database
        {
            get
            {
                MongoClient client = new MongoClient(_connectionString);
                return client.GetDatabase(_databaseName);
            }
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        private IMongoCollection<ScenarioQueryDto> Collection => Database.GetCollection<ScenarioQueryDto>("ScenarioProjection");


        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ScenarioQueryDto> Get(Guid id)
        {
            return await this.Collection.Find(s => s.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Adds the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        public async Task Add(ScenarioQueryDto scenario)
        {
            await this.Collection.InsertOneAsync(scenario);
        }

        /// <summary>
        /// Updates the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        public async Task Update(ScenarioQueryDto scenario)
        {
            await this.Collection.ReplaceOneAsync(s => s.Id == scenario.Id, scenario);
        }

        /// <summary>
        /// Removes the scenario with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task Remove(Guid id)
        {
            await this.Collection.DeleteOneAsync(s => s.Id == id);
        }

        /// <summary>
        /// Gets all the scenarios.
        /// </summary>
        /// <returns>
        /// A collection of all scenarios.
        /// </returns>
        public Task<IEnumerable<ScenarioQueryDto>> GetAll()
        {
            return Task.FromResult(this.Collection.Find(s => true).ToEnumerable());
        }
    }
}