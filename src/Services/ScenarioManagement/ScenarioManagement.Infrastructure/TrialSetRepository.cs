using System;
using System.Collections.Generic;
using MongoDB.Driver;
using ScenarioManagement.Domain;

namespace ScenarioManagement.Infrastructure
{
    public class TrialSetRepository : Repository<TrialSet>, ITrialSetRepository
    {
        /// <summary>
        /// Adds the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        public void Add(TrialSet trialSet)
        {
            this.Collection.InsertOne(trialSet);
        }

        /// <summary>
        /// Updates the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        public void Update(TrialSet trialSet)
        {
            this.Collection.ReplaceOne(t => t.Id == trialSet.Id, trialSet);
        }

        /// <summary>
        /// Gets the trial set.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TrialSet Get(Guid id)
        {
            return this.Collection.Find(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets all trial sets.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TrialSet> GetAll()
        {
            return this.Collection.Find(t => true).ToList();
        }

        /// <summary>
        /// Deletes the trial set with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            this.Collection.DeleteOne(t => t.Id == id);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string or the name of a connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public TrialSetRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <value>
        /// The name of the collection.
        /// </value>
        protected override string CollectionName => "TrialSet";
    }
}
