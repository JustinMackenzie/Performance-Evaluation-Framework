using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ScenarioManagement.API.IntegrationEvents.Events;

namespace ScenarioManagement.API.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.API.Repositories.IProcedureQueryRepository" />
    public class ProcedureQueryRepository : IProcedureQueryRepository
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
        public ProcedureQueryRepository(string connectionString, string databaseName)
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
        private IMongoCollection<ProcedureQueryDto> Collection => Database.GetCollection<ProcedureQueryDto>("ProcedureProjection");

        /// <summary>
        /// Adds the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        public async Task Add(ProcedureQueryDto procedure)
        {
            await this.Collection.InsertOneAsync(procedure);
        }

        /// <summary>
        /// Gets the specified procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        public async Task<ProcedureQueryDto> Get(Guid procedureId)
        {
            return await this.Collection.Find(p => p.Id == procedureId).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProcedureQueryDto>> GetAll()
        {
            return await this.Collection.Find(p => true).ToListAsync();
        }
    }
}