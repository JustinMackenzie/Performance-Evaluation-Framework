using System;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ScenarioManagement.Domain;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.IScenarioRepository" />
    public class ScenarioRepository : IScenarioRepository
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
        private IMongoCollection<Scenario> Collection => Database.GetCollection<Scenario>("Scenario");

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRepository" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <exception cref="ArgumentNullException">
        /// connectionString
        /// or
        /// databaseName
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The connection string or name of the connection string cannot be empty. - connectionString
        /// or
        /// The database name cannot be empty. - databaseName
        /// </exception>
        public ScenarioRepository(string connectionString, string databaseName)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == string.Empty)
                throw new ArgumentException("The connection string or name of the connection string cannot be empty.", nameof(connectionString));
            if (databaseName == null)
                throw new ArgumentNullException(nameof(databaseName));
            if (databaseName == string.Empty)
                throw new ArgumentException("The database name cannot be empty.", nameof(databaseName));

            this._connectionString = connectionString;
            this._databaseName = databaseName;
            this.RegisterClassMaps();
        }

        /// <summary>
        /// Registers the class maps.
        /// </summary>
        private void RegisterClassMaps()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
            {
                BsonClassMap.RegisterClassMap<Entity>(cm =>
                {
                    cm.AutoMap();
                    cm.MapField("_id").SetElementName("Id");
                    cm.SetIsRootClass(true);
                    cm.AddKnownType(typeof(Scenario));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Scenario)))
            {
                BsonClassMap.RegisterClassMap<Scenario>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(s => s.Name);
                    cm.MapField("_scenarioAssets").SetElementName("ScenarioAssets");
                    cm.MapCreator(s => new Scenario(s.Name));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(ScenarioAsset)))
            {
                BsonClassMap.RegisterClassMap<ScenarioAsset>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(a => a.Tag);
                    cm.MapProperty(a => a.Position);
                    cm.MapProperty(a => a.Rotation);
                    cm.MapProperty(a => a.Scale);
                    cm.MapCreator(a => new ScenarioAsset(a.Tag, a.Position, a.Rotation, a.Scale));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Vector)))
            {
                BsonClassMap.RegisterClassMap<Vector>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(v => v.X);
                    cm.MapProperty(v => v.Y);
                    cm.MapProperty(v => v.Z);
                    cm.MapCreator(v => new Vector(v.X, v.Y, v.Z));
                });
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Scenario> Get(Guid id)
        {
            return await this.Collection.Find(s => s.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Adds the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        public async Task Add(Scenario scenario)
        {
            await this.Collection.InsertOneAsync(scenario);
        }

        /// <summary>
        /// Updates the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        public async Task Update(Scenario scenario)
        {
            await this.Collection.ReplaceOneAsync(s => s.Id == scenario.Id, scenario);
        }
    }
}
