using System;
using System.Configuration;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Utility;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    /// <summary>
    /// A generic entity repository implemented with MongoDb.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ScenarioSim.Core.Interfaces.IEntityRepository{T}" />
    public abstract class MongoDbEntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        /// <summary>
        /// The connection string name
        /// </summary>
        private readonly string connectionStringOrName;

        /// <summary>
        /// The database name
        /// </summary>
        private readonly string databaseName;

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        private string ConnectionString
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings[connectionStringOrName].ConnectionString;
                return string.IsNullOrEmpty(connectionString) ? connectionStringOrName : connectionString;
            }
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        protected IMongoDatabase Database
        {
            get
            {
                MongoClient client = new MongoClient(ConnectionString);
                return client.GetDatabase(databaseName);
            }
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        private IMongoCollection<T> Collection => Database.GetCollection<T>(typeof (T).Name); 

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbEntityRepository{T}"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        protected MongoDbEntityRepository(string connectionStringOrName, string databaseName)
        {
            if (connectionStringOrName == null)
                throw new ArgumentNullException(nameof(connectionStringOrName));
            if (connectionStringOrName == string.Empty)
                throw new ArgumentException("The connection string or name of the connection string cannot be empty.", nameof(connectionStringOrName));
            if (databaseName == null)
                throw new ArgumentNullException(nameof(databaseName));
            if (databaseName == string.Empty)
                throw new ArgumentException("The database name cannot be empty.", nameof(databaseName));

            this.connectionStringOrName = connectionStringOrName;
            this.databaseName = databaseName;

            RegisterMapIfNeeded<ReactionTaskValues>();
            RegisterMapIfNeeded<FittsTaskValues>();
            RegisterMapIfNeeded<SteeringTaskValues>();
            RegisterMapIfNeeded<SimulatorEvent>();
            RegisterMapIfNeeded<PerformerAction>();
            RegisterMapIfNeeded<GoalCompletedEvent>();
            RegisterMapIfNeeded<DynamicFittsTaskValues>();
            RegisterMapIfNeeded<RandomReactionTaskValues>();
            RegisterMapIfNeeded<Quaternion>();
            RegisterMapIfNeeded<Vector3f>();
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual T Get(Guid id)
        {
            return Collection.Find(e => e.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return Collection.Find(x => true).ToList();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Remove(T entity)
        {
            Collection.DeleteOne(e => e.Id == entity.Id);
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Save(T entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                Collection.InsertOne(entity);
                return;
            }

            if (Get(entity.Id) == null)
            {
                Collection.InsertOne(entity);
                return;
            }

            Collection.ReplaceOne(e => e.Id == entity.Id, entity);
        }

        /// <summary>
        /// Registers the map if needed.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        private void RegisterMapIfNeeded<TClass>()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TClass)))
                BsonClassMap.RegisterClassMap<TClass>();
        }
    }
}
