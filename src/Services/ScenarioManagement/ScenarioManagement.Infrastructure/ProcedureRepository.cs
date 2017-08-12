using System;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ScenarioManagement.Domain;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Infrastructure
{
    public class ProcedureRepository : IProcedureRepository
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
        private IMongoCollection<Procedure> Collection => Database.GetCollection<Procedure>("Procedure");

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureRepository" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public ProcedureRepository(string connectionString, string databaseName)
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
        /// Adds the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        public async Task Add(Procedure procedure)
        {
            await this.Collection.InsertOneAsync(procedure);
        }

        /// <summary>
        /// Updates the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        public async Task Update(Procedure procedure)
        {
            await this.Collection.ReplaceOneAsync(p => p.Id == procedure.Id, procedure);
        }

        /// <summary>
        /// Deletes the specified procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        public async Task Delete(Guid procedureId)
        {
            await this.Collection.DeleteOneAsync(p => p.Id == procedureId);
        }

        /// <summary>
        /// Gets the specified procedure.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <returns></returns>
        public async Task<Procedure> Get(Guid procedureId)
        {
            return await this.Collection.Find(p => p.Id == procedureId).SingleOrDefaultAsync();
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
                    cm.AddKnownType(typeof(Procedure));
                    cm.AddKnownType(typeof(Scenario));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Procedure)))
            {
                BsonClassMap.RegisterClassMap<Procedure>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(s => s.Name);
                    cm.MapField("_scenarios").SetElementName("Scenarios");
                    cm.MapCreator(p => new Procedure(p.Name));
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
    }
}
