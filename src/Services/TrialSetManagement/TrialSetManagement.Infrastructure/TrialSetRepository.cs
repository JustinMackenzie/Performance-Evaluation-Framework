using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using TrialSetManagement.Domain;

namespace TrialSetManagement.Infrastructure
{
    public class TrialSetRepository : Repository<TrialSet>, ITrialSetRepository
    {
        /// <summary>
        /// Adds the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        public async Task Add(TrialSet trialSet)
        {
            await this.Collection.InsertOneAsync(trialSet);
        }

        /// <summary>
        /// Updates the specified trial set.
        /// </summary>
        /// <param name="trialSet">The trial set.</param>
        public async Task Update(TrialSet trialSet)
        {
            await this.Collection.ReplaceOneAsync(t => t.Id == trialSet.Id, trialSet);
        }

        /// <summary>
        /// Gets the trial set.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TrialSet> Get(Guid id)
        {
            return await this.Collection.Find(t => t.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Deletes the trial set with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(Guid id)
        {
            await this.Collection.DeleteOneAsync(t => t.Id == id);
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
