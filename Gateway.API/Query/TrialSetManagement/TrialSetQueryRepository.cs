using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gateway.API.Query.ScenarioManagement;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Gateway.API.Query.TrialSetManagement
{
    public class TrialSetQueryRepository : ITrialSetQueryRepository
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
        private IMongoCollection<TrialSetQueryDto> Collection => Database.GetCollection<TrialSetQueryDto>("TrialSetProjection");

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetQueryRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public TrialSetQueryRepository(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;

            this.RegisterClassMaps();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TrialSetQueryDto>> GetAll()
        {
            return await this.Collection.Find(t => true).ToListAsync();
        }

        /// <summary>
        /// Gets the trial set.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TrialSetQueryDto> GetTrialSet(Guid id)
        {
            return await this.Collection.Find(t => t.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Updates the specified trial set query.
        /// </summary>
        /// <param name="trialSetQuery">The trial set query.</param>
        /// <returns></returns>
        public async Task Update(TrialSetQueryDto trialSetQuery)
        {
            await this.Collection.ReplaceOneAsync(t => t.Id == trialSetQuery.Id, trialSetQuery);
        }

        /// <summary>
        /// Adds the specified trial set query.
        /// </summary>
        /// <param name="trialSetQuery">The trial set query.</param>
        /// <returns></returns>
        public async Task Add(TrialSetQueryDto trialSetQuery)
        {
            await this.Collection.InsertOneAsync(trialSetQuery);
        }

        /// <summary>
        /// Registers the class maps.
        /// </summary>
        private void RegisterClassMaps()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TrialSetQueryDto)))
            {
                BsonClassMap.RegisterClassMap<TrialSetQueryDto>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(t => t.Id);
                    cm.MapProperty(t => t.Name);
                    cm.MapProperty(t => t.Scenarios);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(ScenarioQueryDto)))
            {
                BsonClassMap.RegisterClassMap<ScenarioQueryDto>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(s => s.Id);
                    cm.MapProperty(s => s.Name);
                    cm.MapProperty(s => s.Assets);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(AssetQueryDto)))
            {
                BsonClassMap.RegisterClassMap<AssetQueryDto>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(a => a.AssetId);
                    cm.MapProperty(a => a.Tag);
                    cm.MapProperty(a => a.Position);
                    cm.MapProperty(a => a.Rotation);
                    cm.MapProperty(a => a.Scale);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(VectorQueryDto)))
            {
                BsonClassMap.RegisterClassMap<VectorQueryDto>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(v => v.X);
                    cm.MapProperty(v => v.Y);
                    cm.MapProperty(v => v.Z);
                });
            }
        }
    }
}
