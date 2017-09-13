using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Gateway.API.Query.PerformanceEvaluation
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ITrialAnalysisRepository" />
    public class TrialAnalysisRepository : ITrialAnalysisRepository
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
        /// Initializes a new instance of the <see cref="TrialAnalysisRepository" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public TrialAnalysisRepository(string connectionString, string databaseName)
        {
            this._connectionString = connectionString;
            this._databaseName = databaseName;

            this.RegisterClassMaps();
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
        private IMongoCollection<TrialAnalysis> Collection => Database.GetCollection<TrialAnalysis>("TrialAnalysis");

        /// <summary>
        /// Adds the specified analysis.
        /// </summary>
        /// <param name="analysis">The analysis.</param>
        /// <returns></returns>
        public async Task Add(TrialAnalysis analysis)
        {
            await this.Collection.InsertOneAsync(analysis);
        }

        /// <summary>
        /// Gets the trial analysis.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TrialAnalysis> GetTrialAnalysis()
        {
            return this.Collection.AsQueryable();
        }

        /// <summary>
        /// Registers the class maps.
        /// </summary>
        private void RegisterClassMaps()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TrialAnalysis)))
            {
                BsonClassMap.RegisterClassMap<TrialAnalysis>(cm =>
                {
                    cm.AutoMap();
                });
            }
        }
    }
}