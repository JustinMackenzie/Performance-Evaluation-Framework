using System;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Schema.Domain;
using Schema.Domain.SeedWork;

namespace Schema.Infrastructure
{
    /// <summary>
    /// An implementation of the schema repository interface using MongoDB
    /// as a storage mechanism.
    /// </summary>
    /// <seealso cref="ISchemaRepository" />
    public class SchemaRepository : ISchemaRepository
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
        private IMongoCollection<Domain.Schema> Collection => Database.GetCollection<Domain.Schema>("Schema");

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRepository" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public SchemaRepository(string connectionString, string databaseName)
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

            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
            {
                BsonClassMap.RegisterClassMap<Entity>(cm =>
                {
                    cm.AutoMap();
                    cm.MapField("_id").SetElementName("Id");
                    cm.SetIsRootClass(true);
                    cm.AddKnownType(typeof(Domain.Schema));
                    cm.AddKnownType(typeof(Scenario));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Domain.Schema)))
            {
                BsonClassMap.RegisterClassMap<Domain.Schema>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(s => s.Name);
                    cm.MapProperty(s => s.Description);
                    cm.MapCreator(schema => new Domain.Schema(schema.Name, schema.Description));
                    cm.MapField("_scenarios").SetElementName("Scenarios");
                    cm.MapField("_events").SetElementName("Events");
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Scenario)))
            {
                BsonClassMap.RegisterClassMap<Scenario>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(s => s.Name);
                    cm.MapCreator(scenario => new Scenario(scenario.Name));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Event)))
            {
                BsonClassMap.RegisterClassMap<Event>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(e => e.Name);
                    cm.MapCreator(@event => new Event(@event.Name));
                });
            }
        }

        /// <summary>
        /// Adds the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public void Add(Domain.Schema schema)
        {
            this.Collection.InsertOne(schema);
        }

        /// <summary>
        /// Updates the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public void Update(Domain.Schema schema)
        {
            this.Collection.ReplaceOne(s => s.Id == schema.Id, schema);
        }

        /// <summary>
        /// Gets the schema with the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Domain.Schema Get(Guid id)
        {
            return this.Collection.Find(s => s.Id == id).FirstOrDefault();
        }
    }
}
