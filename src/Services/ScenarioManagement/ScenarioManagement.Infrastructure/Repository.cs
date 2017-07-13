using System;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ScenarioManagement.Domain;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : IAggregateRoot
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
        protected IMongoCollection<T> Collection => Database.GetCollection<T>(this.CollectionName);

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <value>
        /// The name of the collection.
        /// </value>
        protected abstract string CollectionName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        protected Repository(string connectionString, string databaseName)
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
                    cm.AddKnownType(typeof(TrialSet));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TrialSet)))
            {
                BsonClassMap.RegisterClassMap<TrialSet>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(s => s.Name);
                    cm.MapCreator(t => new TrialSet(t.Name));
                    cm.MapField("_scenarioIds").SetElementName("ScenarioIds");
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Scenario)))
            {
                BsonClassMap.RegisterClassMap<Scenario>(cm =>
                {
                    cm.AutoMap();
                });
            }
        }
    }
}
