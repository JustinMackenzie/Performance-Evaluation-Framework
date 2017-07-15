using System;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using TrialManagement.Domain;
using TrialManagement.Domain.SeedWork;

namespace TrialManagement.Infrastructure
{
    public class TrialRepository : ITrialRepository
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
        private IMongoCollection<Trial> Collection => Database.GetCollection<Trial>("Trial");


        /// <summary>
        /// Initializes a new instance of the <see cref="TrialRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public TrialRepository(string connectionString, string databaseName)
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
        /// Adds the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public void Add(Trial schema)
        {
            this.Collection.InsertOne(schema);
        }

        /// <summary>
        /// Gets the schema with the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Trial Get(Guid id)
        {
            return this.Collection.Find(s => s.Id == id).FirstOrDefault();
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
                    cm.AddKnownType(typeof(Trial));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Trial)))
            {
                BsonClassMap.RegisterClassMap<Trial>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(t => t.ScenarioId);
                    cm.MapProperty(t => t.UserId);
                    cm.MapProperty(t => t.Start);
                    cm.MapProperty(t => t.End);
                    cm.MapCreator(t => new Trial(t.ScenarioId, t.UserId, t.Start, t.End));
                    cm.MapField("_events").SetElementName("Events");
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Event)))
            {
                BsonClassMap.RegisterClassMap<Event>(cm =>
                {
                    cm.AutoMap();
                    cm.MapProperty(e => e.Name);
                    cm.MapProperty(e => e.Timestamp);
                    cm.MapProperty(e => e.Properties);
                    cm.MapCreator(e => new Event(e.Name, e.Timestamp, e.Properties));
                });
            }
        }
    }
}
